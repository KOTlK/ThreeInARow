namespace ThreeInARow.Session.Field.Nodes
{
    public interface INode
    {
        Color Color { get; }
        INode GetNeighbour(NodeSide side);
        void ResetNeighbours((NodeSide, INode)[] neighbours);
        void Mark();//Debug
    }
}