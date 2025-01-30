using UnityEngine;
using XNode;

public class ChoiceNode : BaseNode {

    [Input] public int entry;
    public Character otherCharacter;
    public Choice[] choices;
    [NonReorderable][Output(dynamicPortList = true)] public int[] exit;

    public override string GetString()
    {
        string str = "ChoiceNode";
        foreach(Choice c in choices)
        {
            str += "/" + c.shortHand;
        }
        return str;
    }

    public override Choice[] GetChoices()
    {
        return choices;
    }

    public override object GetValue(NodePort port)
    {
        return base.GetValue(port);
    }
}