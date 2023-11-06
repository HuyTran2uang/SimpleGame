using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    [System.Serializable]
    public class PlayerManager
    {
        [SerializeField] PlayerController _playerCtrlPrefab;

        public void SpawnPlayer()
        {
            var ctrl = MonoBehaviour.Instantiate(_playerCtrlPrefab);
        }
    }
}
