using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [Header("Data")]
    public InteractionInputData interactionInputData;
    public InteractionData interactionData;

    [Space, Header("UI")]
    [SerializeField] private InteractionUIPanel uiPanel;
    [Space]
    [Header("Ray Settings")]
    public float rayDistance;
    public float raySphereRadius;

    public LayerMask interatctableLayer;

    private Camera m_cam;
    private bool m_interacting;
    private float m_holdTimer =0f;

    void Awake()
    {
        // Find the main camera in the scene
        m_cam = FindObjectOfType<Camera>();
        if (m_cam == null)
        {
            Debug.LogError("Main Camera not found in the scene.");
        }
    }

    void Update(){
        CheckForInteractable();
        CheckForInteractableInput();

    }

    // Check for interactable objects using raycasting
    void CheckForInteractable(){
        Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
        RaycastHit _hitInfo;
        bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius,out _hitInfo, rayDistance, interatctableLayer);
        if(_hitSomething){
            InteractableBase _interactable = _hitInfo.transform.GetComponent<InteractableBase>();
            if(_interactable!= null){
                if(interactionData.IsEmpty())
                {
                    interactionData.Interactable=_interactable;
                    uiPanel.SetTooltip(_interactable.TooltipMessage);
                }
                else{
                    if(!interactionData.IsSameInteractable(_interactable))
                    {
                        interactionData.Interactable = _interactable;
                        uiPanel.SetTooltip(_interactable.TooltipMessage);
                    }
                    
                }
            }
        }
        else
        {
            uiPanel.ResetUI();
            interactionData.ResetData();
        }

        // Visualize the raycast for debugging purposes
        Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green :Color.red);
    }


    // Check for interaction input from the player
    void CheckForInteractableInput(){
        if(interactionData.IsEmpty()){
            return;

        }
        if(interactionInputData.InteractedClicked){
            m_interacting = true;
            m_holdTimer =0f;
        }
        if(interactionInputData.InteractedReleased){
            m_interacting = false;
            m_holdTimer = 0f;
            uiPanel.UpdatedProgressBar(m_holdTimer);
        }
        if(m_interacting){
            if(!interactionData.Interactable.IsInteractable){
                return;
            }
            if(interactionData.Interactable.HoldInteract){
                m_holdTimer += Time.deltaTime;

                float heldPercent =m_holdTimer/interactionData.Interactable.HoldDuration;

                uiPanel.UpdatedProgressBar(heldPercent);

                if(heldPercent >1 ){
                    interactionData.Interact();
                    m_interacting = false;
                }
            }
            else{
                interactionData.Interact();
                m_interacting = false;
            }
        }

    }

}
