using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class CompletionNode : BaseNode
{
    [Input] public int entry;
    [Output] public int exit;

    [SerializeField] int index;
    public override string GetString()
    {
        return "CompletionNode/" + index + "/";
    }

    public override object GetValue(NodePort port)
    {
        return base.GetValue(port);
    }
}