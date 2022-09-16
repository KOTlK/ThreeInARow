namespace ThreeInARow.Commands
{
    public interface ICommand<in TTarget>
    {
        void Execute(TTarget target);
    }
}