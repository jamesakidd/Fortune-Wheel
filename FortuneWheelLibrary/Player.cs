using System;

namespace FortuneWheelLibrary
{
    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; } = 0;
        public bool isReady { get; set; } = false;

        public Player(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}