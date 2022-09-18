using ThreeInARow.Session.Factories;
using ThreeInARow.Session.Field;
using ThreeInARow.View;
using ThreeInARow.View.Field;

namespace Game.Runtime.Session
{
    public interface ISession : IVisualization<IFieldView>
    {
        IFieldGraph Field { get; }
        void CreateField(IFactory<IFieldGraph> factory);
        void StartGame();
        void StopGame();
    }
}