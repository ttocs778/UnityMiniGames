using UnityEngine;

[CreateAssetMenu(fileName = "New Brain", menuName = "Custom/Brain")]
[System.Serializable]
public class Brain : ScriptableObject
{
    [NonReorderable] public Information[] info;

    public bool HasInfo(int i)
    {
        return (info[i].unlocked);
    }

    public void SetInfo(int i)
    {
        info[i].unlocked = true;
    }
}
