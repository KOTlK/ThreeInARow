using ThreeInARow.Commands;
using ThreeInARow.Commands.Session;
using ThreeInARow.Session.Field.ColorSelector;
using UnityEngine;

namespace ThreeInARow.Input
{
    public class FieldInput : CommandQueue<ISessionCommand>
    {
        [SerializeField] private ClickInputs _nodeInputs;
        [SerializeField] private Palette _palette;

        private void Awake()
        {
            foreach (var input in _nodeInputs.Inputs)
            {
                input.Clicked += OnNodeClick;
            }
        }

        private void OnDestroy()
        {
            foreach (var input in _nodeInputs.Inputs)
            {
                input.Clicked -= OnNodeClick;
            }
        }

        private void OnNodeClick(Vector2Int position)
        {
            PushCommand(new MarkNodeCommand(position, _palette.Current));
        }

    }
}