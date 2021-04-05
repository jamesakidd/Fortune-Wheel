using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ServiceModel;

/*
 * Main Library class for Fortune Wheel game
 * Authors: Anthony Merante & James Kidd
 * Date: April 1 - 2021
 */

namespace FortuneWheelLibrary
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IWheel
    {
        [OperationContract]
        bool AddPlayer(string name, out Player p);
        [OperationContract]
        bool MakeGuess(char c);
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
        [OperationContract]
        void StartGame();
        [OperationContract]
        Dictionary<char, bool> GetLetters();
        [OperationContract]
        string GetCurrentPhrase();
        [OperationContract(IsOneWay = true)]
        void LeaveGame();
        [OperationContract]
        bool GameStarted();
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
        public Dictionary<string, List<string>> Puzzles { get; set; }
        public Dictionary<char, bool> Letters { get; set; }
        public int CurrentPrize { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentPhrase { get; set; }
        public string PuzzleState { get; set; }
        public bool gameOver { get; set; }

        private const string PUZZLE_FILE = "./fortuneWheelPuzzles.json";

        /*                                                                                                                            
           88               88              88b           d88                       88                                 88             
           88               ""    ,d        888b         d888                ,d     88                                 88             
           88                     88        88`8b       d8'88                88     88                                 88             
           88  8b,dPPYba,   88  MM88MMM     88 `8b     d8' 88   ,adPPYba,  MM88MMM  88,dPPYba,    ,adPPYba,    ,adPPYb,88  ,adPPYba,  
           88  88P'   `"8a  88    88        88  `8b   d8'  88  a8P_____88    88     88P'    "8a  a8"     "8a  a8"    `Y88  I8[    ""  
           88  88       88  88    88        88   `8b d8'   88  8PP"""""""    88     88       88  8b       d8  8b       88   `"Y8ba,   
           88  88       88  88    88,       88    `888'    88  "8b,   ,aa    88,    88       88  "8a,   ,a8"  "8a,   ,d88  aa    ]8I  
           88  88       88  88    "Y888     88     `8'     88   `"Ybbd8"'    "Y888  88       88   `"YbbdP"'    `"8bbdP"Y8  `"YbbdP"' 
         */

        public Wheel()
        {
            Players = new List<Player>();
            Puzzles = new Dictionary<string, List<string>>();
            Letters = new Dictionary<char, bool>();
            gameStarted = false;
            gameOver = false;
            CurrentPlayer = 0;
            LoadWheelPrizes();
            LoadLetters();
            LoadPuzzles();
            PickCurrentPuzzle();
            SetInitialPuzzleState();
        }

        /// <summary>
        /// Sets puzzle state string with matching blocks
        /// </summary>
        private void SetInitialPuzzleState()
        {
            PuzzleState = new string(CurrentPhrase.Select(c => c == ' ' ? ' ' : '█').ToArray());
            SetPuzzleState('-');
            SetPuzzleState('&');
            SetPuzzleState('\'');
            SetPuzzleState('.');
        }

        /// <summary>
        /// Will replace any matching blocks in the puzzle state with the given char
        /// </summary>
        /// <param name="c">the char to uncover</param>
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

        /// <summary>
        /// Loads the array used by the prize wheel with various prize values
        /// </summary>
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
            int randomCategory = new Random(DateTime.Now.Millisecond).Next(0, Puzzles.Count);
            int randomPhrase = new Random(DateTime.Now.Millisecond).Next(0, Puzzles.ElementAt(randomCategory).Value.Count);

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

        /*                                                                                             
          .g8"""bgd                                      `7MMF'                            db          
        .dP'     `M                                        MM                                          
        dM'       `  ,6"Yb. `7MMpMMMb.pMMMb.  .gP"Ya       MM         ,pW"Wq.   .P"Ybmmm `7MM  ,p6"bo  
        MM          8)   MM   MM    MM    MM ,M'   Yb      MM        6W'   `Wb :MI  I8     MM 6M'  OO  
        MM.    `7MMF',pm9MM   MM    MM    MM 8M""""""      MM      , 8M     M8  WmmmP"     MM 8M       
        `Mb.     MM 8M   MM   MM    MM    MM YM.    ,      MM     ,M YA.   ,A9 8M          MM YM.    , 
          `"bmmmdPY `Moo9^Yo.JMML  JMML  JMML.`Mbmmd'    .JMMmmmmMMM  `Ybmd9'   YMMMMMb  .JMML.YMbmd'  
                                                                               6'     dP               
                                                                               Ybmmmd'      
        */

        /// <summary>
        /// Adds and validates a new player to the game
        /// </summary>
        /// <param name="name">Name of the player to be created</param>
        /// <param name="p">Player varible to be created and returned in the method</param>
        /// <returns>boolean representing if the player was created succesfully</returns>
        public bool AddPlayer(string name, out Player p)
        {
            p = null;
            if (gameStarted)
            {
                return false;
            }
            if (callbacks.ContainsKey(name.ToUpper()) || Players.Count >= MAX_PLAYERS)
                // User alias must be unique
                return false;
            else
            {
                // Create the player and add them to the list
                p = new Player(name);
                Players.Add(p);
                // Retrieve client's callback proxy
                ICallback cb = OperationContext.Current.GetCallbackChannel<ICallback>();
                // Save alias and callback proxy
                callbacks.Add(p.Name.ToUpper(), cb);
                // update users
                updateAllUsers();
                return true;
            }
        }
        /// <summary>
        /// Signals to the service that the player is leaving the game
        /// </summary>
        public void LeaveGame()
        {
            ICallback cb = OperationContext.Current.GetCallbackChannel<ICallback>();

            if (callbacks.ContainsValue(cb))
            {
                // Identify which client is currently calling this method
                // - Get the index of the client within the callbacks collection
                int i = callbacks.Values.ToList().IndexOf(cb);
                // - Get the unique id of the client as stored in the collection
                string id = callbacks.ElementAt(i).Key;

                // Remove this client from receiving callbacks from the service
                callbacks.Remove(id);
                Players.Remove(Players.Find(e => e.Name.ToUpper() == id));
                if (Players.Count == 1 )
                {
                    CurrentPlayer = 0;
                    gameOver = true;
                    updateAllUsers();
                    return;
                }
                if (Players.Count == 0)
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
                    return;
                }
                updateAllUsers();
            }
        }

        /// <summary>
        /// Increments current player
        /// </summary>
        public void NextPlayer()
        {
            if (CurrentPlayer + 1 >= Players.Count || CurrentPlayer == Players.Count)
            {
                CurrentPlayer = 0;
            }
            else
            {
                CurrentPlayer++;
            }
            updateAllUsers();
        }

        /// <summary>
        ///Triggers all clients callback contracts
        /// </summary>
        private void updateAllUsers()
        {
            Player[] msgs = GetAllPlayers();
            foreach (ICallback cb in callbacks.Values)
                cb.PlayersUpdated(msgs);
        }

        /// <summary>
        /// Updates the given player
        /// </summary>
        /// <param name="p">The player to update</param>
        public void UpdatePlayer(Player p)
        {
            Player play = Players.FirstOrDefault(player => player.Name == p.Name);
            play.Score = p.Score;
            play.isReady = p.isReady;
            updateAllUsers();
        }

        /// <summary>
        /// Counts instances of given char in current puzzle
        /// </summary>
        /// <param name="c">The char the player has guessed</param>
        /// <returns>True - if count > 0</returns>
        public bool MakeGuess(char c)
        {
            Letters[c] = false;
            int count = CurrentPhrase.ToUpper().Count(f => f == c);
            Players[CurrentPlayer].Score += CurrentPrize * count;
            if (count <= 0) return false;
            SetPuzzleState(c);
            return true;
        }

        /// <summary>
        /// Checks if a player's solution guess matches the current puzzle. If so - add current prize X remaining hidden letters to player's score.
        /// </summary>
        /// <param name="playerGuess">The string that the player has entered as a guess</param>
        public void GuessAnswer(string playerGuess)
        {
            if (string.Equals(CurrentPhrase, playerGuess, StringComparison.CurrentCultureIgnoreCase))
            {
                string upperCurrentPhrase = CurrentPhrase.ToUpper();
                int remainingBlocks = Enumerable.Range(0, CurrentPhrase.Length)
                    .Count(i => PuzzleState[i] != upperCurrentPhrase[i]);

                Players[CurrentPlayer].Score += CurrentPrize * remainingBlocks;
                gameOver = true;
            }
            else
            {
                NextPlayer();
            }
            updateAllUsers();
        }


        /*
        .g8"""bgd            mm     mm                           
        .dP'     `M            MM     MM                           
        dM'       `   .gP"Ya mmMMmm mmMMmm .gP"Ya `7Mb,od8 ,pP"Ybd 
        MM           ,M'   Yb  MM     MM  ,M'   Yb  MM' "' 8I   `" 
        MM.    `7MMF'8M""""""  MM     MM  8M""""""  MM     `YMMMa. 
        `Mb.     MM  YM.    ,  MM     MM  YM.    ,  MM     L.   I8 
        `"bmmmdPY   `Mbmmd'  `Mbmo  `Mbmo`Mbmmd'.JMML.   M9mmmP' 
        */


        public Player[] GetAllPlayers()
        {
            return this.Players.ToArray();
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

        public bool GameOver()
        {
            return gameOver;
        }

        public void StartGame()
        {
            gameOver = false;
            gameStarted = true;
        }
        public Dictionary<char, bool> GetLetters()
        {
            return Letters;
        }

        public string GetCurrentPhrase()
        {
            return CurrentPhrase;
        }

        public bool GameStarted()
        {
            return gameStarted;
        }

    }
}