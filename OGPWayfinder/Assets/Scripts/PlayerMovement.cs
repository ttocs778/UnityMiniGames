using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public static Vector3 playerPosition;
    SoundManager soundManager;
    [SerializeField] private float baseSpeed = 10;
    [SerializeField] private float jumpSpeed = 8; // Jump speed
    [SerializeField] private float gravity = 20; // Gravity force
    [SerializeField] private float footstepCooldown = 0.4f; // Interval between footstep sounds
    [SerializeField] private AudioClip footstepsClip; // Assign the footstep loop clip here
    [SerializeField] private AudioClip jumpSound;

    private CharacterController controls;
    private Vector3 velocity;
    private AudioSource footstepAudioSource;
    public static bool locked;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);

        //soundManager = GameObject.FindWithTag("Audio").GetComponent<SoundManager>();
    }

    void Start()
    {
        controls = GetComponent<CharacterController>();
        footstepAudioSource = gameObject.AddComponent<AudioSource>();
        footstepAudioSource.clip = footstepsClip;
        footstepAudioSource.loop = true;
    }

    void Update()
    {
        if (!locked)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 moveLocalTransform = transform.right * x + transform.forward * z;

            // Jumping
            if (controls.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpSpeed;
                PlayJumpSound();
            }

            // Apply gravity
            velocity.y -= gravity * Time.deltaTime;

            // Move the character
            controls.Move((moveLocalTransform * baseSpeed + velocity) * Time.deltaTime);

            bool isMoving = controls.isGrounded && moveLocalTransform.magnitude > 0;

            // Play or stop the footstep loop based on the player's movement
            if (isMoving && !footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play();
            }
            else if (!isMoving && footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop();
            }

            playerPosition = transform.position;
        }
        
    }
    private void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }
    }
}
