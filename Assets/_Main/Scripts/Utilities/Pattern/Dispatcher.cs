using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame.Dispatcher
{
    public abstract class Dispatcher<T> : MonoBehaviour where T : Item
    {
        List<T> _items = new List<T>();

        public void AddToDispatcher(T item)
        {
            _items.Add(item);
            SetValueOfItem(item);
        }

        public void RemoveFromDispatcher(T item)
        {
            _items.Remove(item);
        }

        protected void SetValueOfItems(string value)
        {
            _items.ForEach(i => i.Set(value));
        }

        protected abstract void SetValueOfItem(T item);
    }

    public abstract class DispatcherSingleton<T> : MonoBehaviourSingleton<DispatcherSingleton<T>> where T : Item
    {
        List<T> _items = new List<T>();

        public void AddToDispatcher(T item)
        {
            _items.Add(item);
            SetValueOfItem(item);
        }

        public void RemoveFromDispatcher(T item)
        {
            _items.Remove(item);
        }

        protected void SetValueOfItems(string value)
        {
            _items.ForEach(i => i.Set(value));
        }

        protected abstract void SetValueOfItem(T item);
    }

    public abstract class Item : MonoBehaviour
    {
        UnityEngine.UI.Text _text;

        private void Awake()
        {
            _text = GetComponent<UnityEngine.UI.Text>();
        }

        public void Set(string value)
        {
            _text.text = value.ToString();
        }

        protected abstract void OnEnable(); //add to dispatcher

        protected abstract void OnDisable(); //remove to dispatcher
    }
}
