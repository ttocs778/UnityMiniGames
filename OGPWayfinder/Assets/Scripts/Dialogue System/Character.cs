using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Character", menuName = "Custom/Character")]
public class Character : ScriptableObject
{
    [SerializeField] public bool characterKnown;
    [SerializeField] public string characterName;

    public string GetName()
    {
        return characterName;
        /*
        if (characterKnown)
        {
            return characterName;
        }
        else
        {
            return "???";
        }
        */
    }

    public void MeetCharacter()
    {
        characterKnown = true;
    }
}
