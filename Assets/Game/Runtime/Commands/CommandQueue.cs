using System.Collections.Generic;
using UnityEngine;

namespace ThreeInARow.Commands
{
    public abstract class CommandQueue<T> : MonoBehaviour, ICommandQueue<T>
    {
        private readonly Queue<T> _commands = new();

        public bool HasUnreadCommand => _commands.Count > 0;

        public T ReadCommand()
        {
            return _commands.Dequeue();
        }

        public void Clear()
        {
            _commands.Clear();
        }
        
        protected void PushCommand(T command)
        {
            _commands.Enqueue(command);
        }
    }
}