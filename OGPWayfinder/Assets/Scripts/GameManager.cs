using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool[] completion = new bool[5];

    [HideInInspector] public static GameManager Instance;
    [HideInInspector] private static GameState state;
    
    [SerializeField] PlayerMovement player;
    [SerializeField] PlayerCamera cam;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;

        completion = new bool[5];

        SwitchGameState(GameState.Gameplay);
    }

    private void Update()
    {
        switch (state)
        {
            case GameState.Gameplay:
                //
                break;
            case GameState.Talking:
                //
                break;
            case GameState.Paused:
                //
                break;
        }
    }

    private void Start()
    {
        completion = new bool[5];
    }

    public void SwitchGameState(GameState _state)
    {
        state = _state;

        switch (state)
        {
            case GameState.Gameplay:
                player.enabled = true;
                cam.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                if (IsGameComplete())
                {
                    Debug.Log("Game Complete");
                    Application.Quit();
                }
                break;
            case GameState.Talking:
                player.enabled = false;
                cam.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.Paused:
                player.enabled = false;
                cam.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }

    public bool IsGameComplete()
    {
        foreach (bool b in completion)
        {
            if (!b)
            {
                return false;
            }
        }
        return true;
    }
}
public enum GameState
{
    Gameplay,
    Talking,
    Paused
}