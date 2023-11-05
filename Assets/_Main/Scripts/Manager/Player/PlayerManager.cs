using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    public class PlayerManager
    {
        [SerializeField] PlayerController _playerCtrlPrefab;

        public void SpawnPlayer(MonoBehaviour mono)
        {
            var ctrl = MonoBehaviour.Instantiate(_playerCtrlPrefab);
        }
    }
}
