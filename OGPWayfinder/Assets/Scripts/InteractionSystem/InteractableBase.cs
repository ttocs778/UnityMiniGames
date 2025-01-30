using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour, IInteractable
{
    [Header("Interactable Settings")]
    public float holdDuration;
    public bool holdInteract;
    public bool multipleUse;
    public bool isInteractable;
    public string tooltipMessage = "Interact";
    public float HoldDuration{
        get{ return holdDuration; }
    }
    public bool IsInteractable{
        get{ return isInteractable;}
    }

    public bool MultipleUse{
        get{ return multipleUse;}
    }
    public bool HoldInteract{
        get{ return holdInteract;}
    }

    public string TooltipMessage => tooltipMessage;

    public virtual void OnInteract()
    {

    }





    
}
