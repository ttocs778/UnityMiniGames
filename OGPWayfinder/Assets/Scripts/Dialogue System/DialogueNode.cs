using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueNode : BaseNode
{
    [Input] public int entry;
    [Output] public int exit;

    [SerializeField] Character speaker;
    [TextArea(10,10)]public string dialogueLine;
    public override string GetString()
    {
        return "DialogueNode/" + speaker.GetName() + "/" + dialogueLine + "/";
    }

    public override object GetValue(NodePort port)
    {
        return base.GetValue(port);
    }
}