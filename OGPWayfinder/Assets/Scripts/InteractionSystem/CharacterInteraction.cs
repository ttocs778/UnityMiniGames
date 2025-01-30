using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] DialogueGraph dialog;
    [SerializeField] NodeParser nodeParser;
    [SerializeField] GameObject dialogueContainer;
    SoundManager soundManager;
    
    public GameObject interactUI; // Reference to the UI panel for interaction
    private bool isInRange; // Flag to track if the player is in range for interaction

    // Called when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            isInRange = true; // Set player in range flag to true
            interactUI.SetActive(true); // Activate the interaction UI panel
        }
    }

    // Called when another collider exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            isInRange = false; // Set player in range flag to false
            interactUI.SetActive(false); // Deactivate the interaction UI panel
        }
    }

    // Called every frame
    private void Update()
    {
        // Check if the player is in range and presses the E key
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Perform interaction logic here
            soundManager.PlaySFX(soundManager.Interacting);
            interactUI.SetActive(false);
            dialogueContainer.SetActive(true);
            nodeParser.graph = dialog;
            nodeParser.ParseGraph();
            GameManager.Instance.SwitchGameState(GameState.Talking);
        }
    }
}