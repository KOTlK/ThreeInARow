using ThreeInARow.Session.Factories;
using ThreeInARow.Session.Field;
using ThreeInARow.View.Field;

namespace Game.Runtime.Session
{
    public class Session : ISession
    {
        public Session(IFieldGraph field)
        {
            Field = field;
        }

        public IFieldGraph Field { get; private set; }
        
        public void CreateField(IFactory<IFieldGraph> factory)
        {
            Field = factory.Create();
        }

        public void StartGame()
        {
            throw new System.NotImplementedException();
        }

        public void StopGame()
        {
            throw new System.NotImplementedException();
        }

        public void Visualize(IFieldView view)
        {
            Field.Visualize(view);
        }
    }
}