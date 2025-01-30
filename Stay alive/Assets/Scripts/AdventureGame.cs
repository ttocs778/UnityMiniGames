using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    // SerializeField means we can modify this variable in inspector in uinty;
    [SerializeField] State startingState;
    


    State state;
    void Start()
    {
        state=startingState;
        textComponent.text = state.GetStateStory();
      
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
        
    }

    private void ManageState()
    {   
        var nextStates = state.GetNextStates();
        for(int index = 0; index < nextStates.Length; index++){
            if(Input.GetKeyDown(KeyCode.Alpha1+index)){
                state = nextStates[index];
            }
        }
 
        textComponent.text = state.GetStateStory();
    }
}
