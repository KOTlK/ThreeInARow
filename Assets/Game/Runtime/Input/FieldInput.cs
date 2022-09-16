using ThreeInARow.Commands;
using ThreeInARow.Session.Field;
using UnityEngine;

namespace ThreeInARow.Input
{
    public class FieldInput : MonoBehaviour
    {
        private NodeClickInput[] _nodeInputs;
        private IFieldGraph _field;

        public void Initialize(NodeClickInput[] inputs, IFieldGraph field)
        {
            _nodeInputs = inputs;
            _field = field;
            foreach (var input in _nodeInputs)
            {
                input.Clicked += OnNodeClick;
            }
        }

        public void OnDestroy()
        {
            foreach (var input in _nodeInputs)
            {
                input.Clicked -= OnNodeClick;
            }
        }

        private void OnNodeClick(Vector2Int position)
        {
            new TryMarkNodesCommand(position).Execute(_field);
        }
    }
}