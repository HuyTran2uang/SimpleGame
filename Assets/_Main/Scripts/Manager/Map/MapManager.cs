using UnityEngine;

namespace SimpleGame
{
    [System.Serializable]
    public class MapManager
    {
        [SerializeField] Grid _grid;

        public void Init()
        {
            _grid = new Grid(10, 15, 1, 1);
        }

        [SerializeField] bool _isShowGizmos;
        public void OnDrawGizmos()
        {
            if (!_isShowGizmos) return;
            for (int x = 0; x < _grid.Width; x++)
            {
                for (int y = 0; y < _grid.Width; y++)
                {
                    Gizmos.color = _grid.GetNode(x, y).Walkable ? Color.green : Color.red;
                    Gizmos.DrawCube(_grid.GetNode(x, y).CenterPos, new Vector2(_grid.CellWidth, _grid.CellHeight) * .9f);
                }
            }
        }
    }
}
