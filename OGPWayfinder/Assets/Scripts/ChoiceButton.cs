using UnityEngine;
using System;

public class ChoiceButton : MonoBehaviour
{
    int index;
    public static Action<int> DialogueChoice;

    public void SendIndex()
    {
        DialogueChoice(index);
    }

    public void SetIndex(int i)
    {
        index = i;
    }
}