
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("------Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("------Audio Source--------")]
    public AudioClip background;
    public AudioClip footsteps;
    public AudioClip Interacting;
    public AudioClip jumpSound;

    private void Start(){
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
