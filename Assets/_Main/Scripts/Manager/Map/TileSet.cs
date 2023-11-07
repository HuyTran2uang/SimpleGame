using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    public class TileSet
    {
        
    }

    public class Tile
    {
        public int Id { get; private set; }
        public Sprite Sprite { get; private set;}
        public int LayerId { get; private set; }
    }
}