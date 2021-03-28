using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FortuneWheelLibrary
{
    public class Wheel
    {
        public List<Player> Players { get; set; }
        public List<int> WheelPrizes { get; set; }
        public Dictionary<string, List<string>> Puzzles { get; set; } //Key: Category Value: A List of possible phrases.
        public Dictionary<char, bool> Letters { get; set; } //A letter and bool for if it's available to play.
        public int CurrentPrize { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentPhrase { get; set; }


        private const string PUZZLE_FILE = "./fortuneWheelPuzzles.json";

        public Wheel()
        {
            Players = new List<Player>();
            Puzzles = new Dictionary<string, List<string>>();
            Letters = new Dictionary<char, bool>();

            LoadWheelPrizes();
            LoadLetters();
            LoadPuzzles();
            PickCurrentPuzzle();
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
        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
    }

}