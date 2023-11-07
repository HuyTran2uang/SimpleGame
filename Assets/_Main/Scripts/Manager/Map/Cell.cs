using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] List<SpriteRenderer> _srs = new List<SpriteRenderer>();

        public void Add(Sprite sprite, int layerID)
        {
            GameObject go = new GameObject(sprite.name);
            SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = sprite;
            sr.sortingLayerID = layerID;
            go.transform.SetSiblingIndex(layerID);
            _srs.Add(sr);
        }
    }
}
