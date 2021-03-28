﻿namespace FortuneWheelLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
        }
    }
}