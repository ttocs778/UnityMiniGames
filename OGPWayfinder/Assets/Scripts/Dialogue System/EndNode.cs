public class EndNode : BaseNode
{
    [Input] public int entry;

    public override string GetString()
    {
        return "End";
    }
}