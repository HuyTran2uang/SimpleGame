using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    public class Grid
    {
        int _width, _height;
        Node[,] _nodes;
        float _space;

        public Node GetNode(int x, int y)
        {
            return _nodes[x, y];
        }

        //public Node GetNode(Vector3 pos)
        //{
        //    return _nodes[];
        //}

        public IEnumerable<Node> GetNeighbourNodes(int x, int y)
        {
            if (x - 1 >= 0) yield return _nodes[x - 1, y];
            if (x + 1 < _width) yield return _nodes[x + 1, y];
            if (y - 1 >= 0) yield return _nodes[x, y - 1];
            if (y + 1 < _height) yield return _nodes[x, y + 1];
        }

        public IEnumerable<Node> GetNeighbourNodes(Node node)
        {
            return GetNeighbourNodes(node.X, node.Y);
        }

        //public IEnumerable<Node> GetNeighbourNodes(Node node)
        //{
        //    if (node.X - 1 >= 0) yield return _nodes[node.X - 1, node.Y];
        //    if (node.X + 1 < _width) yield return _nodes[node.X + 1, node.Y];
        //    if (node.Y - 1 >= 0) yield return _nodes[node.X, node.Y - 1];
        //    if (node.Y + 1 < _height) yield return _nodes[node.X, node.Y + 1];
        //}
    }
}
