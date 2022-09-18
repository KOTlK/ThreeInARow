using Game.Runtime.Session;
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
        
        private ISession _session;

        private void Awake()
        {
            _session = new Game.Runtime.Session.Session(
                new FieldFactory(
                    _fieldSize,
                    new RandomColor()
                ).Create()
            );
            
            _session.Visualize(_fieldView);

        }

        private void Update()
        {
            if (_fieldInput.HasUnreadCommand)
            {
                _fieldInput.ReadCommand().Execute(_session);
            }
            _session.Visualize(_fieldView);
        }
    }
}