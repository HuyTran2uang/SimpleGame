using UnityEngine;

namespace SimpleGame
{
    public class InputManager
    {
        public void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }
}
