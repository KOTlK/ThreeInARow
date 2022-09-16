using ThreeInARow.Input;
using ThreeInARow.Session.Factories;
using ThreeInARow.Session.Field;
using ThreeInARow.Session.Random;
using ThreeInARow.View.Field;
using UnityEngine;

namespace ThreeInARow.Application
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private FieldView _fieldView;
        [SerializeField] private FieldInput _fieldInput;
        [SerializeField] private Vector2Int _fieldSize = new Vector2Int(10, 10);
        
        private IFieldGraph _field;

        private void Awake()
        {
            _field = new FieldFactory(
                _fieldSize,
                new RandomColor()
            ).Create();
            _field.Visualize(_fieldView);

            var nodeInputs = _fieldView.GetComponentsInChildren<NodeClickInput>();
            _fieldInput.Initialize(nodeInputs, _field);
        }

        private void Update()
        {
            _field.Visualize(_fieldView);
        }
    }
}