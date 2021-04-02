using System.Runtime.Serialization;

/*
 * Player class for Fortune Wheel game
 * Authors: Anthony Merante & James Kidd
 * Date: April 1 - 2021
 */

namespace FortuneWheelLibrary
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Score { get; set; }

        [DataMember]
        public bool isReady { get; set; }

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