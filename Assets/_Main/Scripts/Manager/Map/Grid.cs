using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    [System.Serializable]
    public class Grid
    {
        int _width, _height;
        Node[,] _nodes;
        float _cellWidth, _cellHeight;
        Vector3 _botLeftPos = new Vector3(-6.5f, -4.5f, 0);
        public int Width => _width;
        public int Height => _height;
        public float CellWidth => _cellWidth;
        public float CellHeight => _cellHeight;

        public Grid(int width, int height, int cellWidth, int cellHeight)
        {
            _width = width;
            _height = height;
            _cellWidth = cellWidth;
            _cellHeight = cellHeight;
            _nodes = new Node[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _nodes[x, y] = new Node(x, y, _botLeftPos + new Vector3(cellWidth * x, cellHeight * y, 0), true);
                }
            }
        }

        public Node GetNode(int x, int y)
        {
            return _nodes[x, y];
        }

        public Node GetNode(Vector3 pos)
        {
            Vector3Int cell = Vector3Int.FloorToInt(pos);
            return _nodes[cell.x, cell.y];
        }

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
    }
}
