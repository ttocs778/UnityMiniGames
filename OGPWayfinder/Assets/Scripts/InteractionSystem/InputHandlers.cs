using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlers : MonoBehaviour
{
    public  InteractionInputData interactionInputData;
    [SerializeField] private float interactionRange = 2.0f; // Interaction range in meters
    [SerializeField] private LayerMask interactableLayer; 
    SoundManager soundManager;
    void Start(){
        interactionInputData.ResetInput();
        soundManager = GameObject.FindObjectOfType<SoundManager>();

    }
    void Update(){
        GetInteractionInputData();
    }


    void GetInteractionInputData()
    {
        bool interactedClicked = Input.GetKeyDown(KeyCode.E);
        interactionInputData.InteractedClicked = interactedClicked;
        interactionInputData.InteractedReleased = Input.GetKeyUp(KeyCode.E);
        if (interactedClicked)
        {
            soundManager?.PlaySFX(soundManager.Interacting);
        }


    }

}


