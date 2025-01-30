using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Interaction Data", menuName = "InteractionSystem/InteractionData")]
public class InteractionData : ScriptableObject
{
    private InteractableBase m_interactale;
    public InteractableBase Interactable
    {
        get { return m_interactale;}
        set { m_interactale = value;}
    }

    public void Interact(){
        m_interactale.OnInteract();
        ResetData();

    }
    public bool IsSameInteractable(InteractableBase _newInteractable)
    {
        return m_interactale == _newInteractable;
    }
    public bool IsEmpty() {
        return m_interactale == null;

    }
    public void ResetData()
    {
        m_interactale = null;
    }

}
