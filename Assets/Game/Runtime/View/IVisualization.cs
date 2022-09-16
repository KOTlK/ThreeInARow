namespace ThreeInARow.View
{
    public interface IVisualization<in TView>
    {
        void Visualize(TView view);
    }
}