using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class InfoNode : BaseNode {

    [Input] public int entry;
    [Output] public int exit;
    public int infoIndex;

    public override string GetString()
    {
        return "InfoNode/" + infoIndex;
    }
    public override object GetValue(NodePort port)
    {
        return base.GetValue(port);
    }
}