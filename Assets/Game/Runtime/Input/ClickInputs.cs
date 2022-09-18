using System.Collections.Generic;
using UnityEngine;

namespace ThreeInARow.Input
{
    public class ClickInputs : MonoBehaviour
    {

        private readonly List<NodeClickInput> _inputs = new();

        public IEnumerable<NodeClickInput> Inputs => _inputs;

        public void Append(NodeClickInput input)
        {
            _inputs.Add(input);
        }

        public void Remove(NodeClickInput input)
        {
            _inputs.Remove(input);
        }
    }
}