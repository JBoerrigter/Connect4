using System;

namespace Connect4.Domain
{
    public class Chip
    {
        public Player Owner { get; private set; }
        
        public Chip(Player owner)
        {
            Owner = owner;
        }
    }
}
