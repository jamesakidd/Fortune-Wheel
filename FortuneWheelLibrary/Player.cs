using System;
using System.Runtime.Serialization;

namespace FortuneWheelLibrary
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Score { get; set; } = 0;

        [DataMember]
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