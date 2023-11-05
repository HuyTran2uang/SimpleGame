using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    public class Node
    {
        private int _x, _y;
        private Vector3 _centerPos;
        private bool _walkable;
        private int _gCost, _hCost;

        public Node(int x, int y, Vector3 centerPos, bool walkable)
        {
            _x = x;
            _y = y;
            _centerPos = centerPos;
            _walkable = walkable;
        }

        public int X => _x;
        public int Y => _y;
        public int GCost {  get { return _gCost; } set { _gCost = value; } }
        public int HCost {  get { return _hCost; } set { _hCost = value; } }
        public int FCost => _gCost + _hCost;
    }
}
