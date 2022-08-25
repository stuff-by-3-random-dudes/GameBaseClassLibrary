using System;

namespace GameBaseClassLibrary
{
    [Serializable]
    public class GameBases
    {
        public string Name { get; set; }
        public Regions Region { get; set; }
        public string Path { get; set; }
        public string Tid { get; set; }
        public int KeyHash { get; set; }
    }
}
