using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ServiceModel;

namespace FortuneWheelLibrary
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IWheel
    {
        [OperationContract]
        bool AddPlayer(Player player);
        [OperationContract]
        void MakeGuess(char c);
        [OperationContract]
        void GuessAnswer(string playerGuess);
        [OperationContract]
        Player[] GetAllPlayers();
        [OperationContract]
        void UpdatePlayer(Player p);
        [OperationContract]
        int CurrentPrize();
        [OperationContract]
        void SetPrize(int p);
        [OperationContract]
        List<int> GetPrizes();
        [OperationContract]
        string GetCurrentState();
        [OperationContract]
        string GetCurrentCategory();
        [OperationContract]
        Player GetCurrentPlayer();
        [OperationContract]
        void NextPlayer();
        [OperationContract]
        bool GameOver();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Wheel : IWheel
    {
        const int MAX_PLAYERS = 4;
        private Dictionary<string, ICallback> callbacks = new Dictionary<string, ICallback>();
        public bool gameStarted { get; set; }
        public List<Player> Players { get; set; }
        public int CurrentPlayer { get; set; }
        public List<int> WheelPrizes { get; set; }
        public Dictionary<string, List<string>> Puzzles { get; set; } //Key: Category Value: A List of possible phrases.
        public Dictionary<char, bool> Letters { get; set; } //A letter and bool for if it's available to play.
        public int CurrentPrize { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentPhrase { get; set; }
        public string PuzzleState { get; set; }
        public bool gameOver { get; set; }


        private const string PUZZLE_FILE = "./fortuneWheelPuzzles.json";

        public Wheel()
        {
            Players = new List<Player>();
            Puzzles = new Dictionary<string, List<string>>();
            Letters = new Dictionary<char, bool>();
            gameStarted = false;
            CurrentPlayer = 0;
            LoadWheelPrizes();
            LoadLetters();
            LoadPuzzles();
            PickCurrentPuzzle();
            SetInitialPuzzleState();
        }

        private void SetInitialPuzzleState()
        {
            char square = Convert.ToChar(254);
            PuzzleState = new string(CurrentPhrase.Select(c => c == ' ' ? ' ' : '█').ToArray());
            SetPuzzleState('-');
            SetPuzzleState('&');
            SetPuzzleState('\'');
            SetPuzzleState('.');
        }

        private void SetPuzzleState(char c)
        {
            StringBuilder sb = new StringBuilder(PuzzleState);
            string upperCurrentPhrase = CurrentPhrase.ToUpper();
            for (int i = 0; i < CurrentPhrase.Length; i++)
            {
                if (upperCurrentPhrase[i] == c)
                {
                    sb[i] = c;
                }
            }

            PuzzleState = sb.ToString();
        }

        private void LoadWheelPrizes()
        {
            WheelPrizes = new List<int>
            {   
                3500,
                500,
                750,
                100,
                2000,
                5000,
                10,
                1000
            };
        }

        /// <summary>
        /// Randomly selects a category and subsequent phrase from that category to use as the current puzzle
        /// </summary>
        private void PickCurrentPuzzle()
        {
            int randomCategory = new Random().Next(0, Puzzles.Count);
            int randomPhrase = new Random().Next(0, Puzzles.ElementAt(randomCategory).Value.Count);

            CurrentCategory = Puzzles.ElementAt(randomCategory).Key;
            CurrentPhrase = Puzzles.ElementAt(randomCategory).Value[randomPhrase];
        }

        /// <summary>
        /// Loads puzzle dictionary from JSON file
        /// </summary>
        private void LoadPuzzles()
        {
            try
            {
                string jsonString = File.ReadAllText(PUZZLE_FILE);
                Puzzles = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR LOADING PUZZLE FILE: {ex.Message}");
            }
            
        }

        /// <summary>
        /// Loads letters dictionary with A to Z uppercase
        /// </summary>
        private void LoadLetters()
        {
            for (int i = 65; i <= 90; i++)
            {
                Letters.Add(Convert.ToChar(i), true);
            }
        }

        /// <summary>
        /// Adds a player to the list of players
        /// </summary>
        /// <param name="player">The player to be added</param>
        public bool AddPlayer(Player player)
        {
            if (callbacks.ContainsKey(player.Name.ToUpper()) || Players.Count >= MAX_PLAYERS)
                // User alias must be unique
                return false;
            else
            {
                Players.Add(player);
                // Retrieve client's callback proxy
                ICallback cb = OperationContext.Current.GetCallbackChannel<ICallback>();
                // Save alias and callback proxy
                callbacks.Add(player.Name.ToUpper(), cb);
                updateAllUsers();
                return true;
            }
        }

        private void updateAllUsers()
        {
            Player[] msgs = GetAllPlayers();
            foreach (ICallback cb in callbacks.Values)
                cb.PlayersUpdated(msgs);
        }

        public void MakeGuess(char c)
        {
            int count = CurrentPhrase.ToUpper().Count(f => f == c);
            if(count > 0)
                SetPuzzleState(c);

            Players[CurrentPlayer].Score += CurrentPrize * count;
        }

        public void GuessAnswer(string playerGuess)
        {
            gameOver = string.Equals(CurrentPhrase, playerGuess, StringComparison.CurrentCultureIgnoreCase);
            updateAllUsers();
        }

        public Player[] GetAllPlayers()
        {
            return this.Players.ToArray();
        }

        public void UpdatePlayer(Player p)
        {
            Player play = Players.FirstOrDefault(player => player.Name == p.Name);
            play.Score = p.Score;
            play.isReady = p.isReady;
            updateAllUsers();
        }

        int IWheel.CurrentPrize()
        {
            return CurrentPrize;
        }

        public List<int> GetPrizes()
        {
            return WheelPrizes;
        }

        public void SetPrize(int prize)
        {
            CurrentPrize = prize;
        }

        public string GetCurrentState()
        {
            return PuzzleState;
        }

        public string GetCurrentCategory()
        {
            return CurrentCategory;
        }

        public Player GetCurrentPlayer()
        {
            return Players[CurrentPlayer];
        }

        public void NextPlayer()
        {
            if (CurrentPlayer+1 >= Players.Count)
            {
                CurrentPlayer = 0;
            }
            else
            {
                CurrentPlayer++;
            }
            updateAllUsers();
        }

        public bool GameOver()
        {
            return gameOver;
        }
    }
}