using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        [field: SerializeField] public PlayerManager PlayerManager { get; set; }
        [field: SerializeField] public MapManager MapManager { get; set; }
        [field: SerializeField] public InputManager InputManager { get; set; }

        private void Awake()
        {

        }

        private void Start()
        {
            //
            PlayerManager = new PlayerManager();
            MapManager = new MapManager();
            InputManager = new InputManager();
            //
            MapManager.Init();
        }

        private void Update()
        {
            InputManager.Update();
        }

        private void FixedUpdate()
        {

        }

        private void OnDrawGizmos()
        {
            MapManager.OnDrawGizmos();
        }
    }
}
