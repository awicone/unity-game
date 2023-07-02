using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepSounds : MonoBehaviour
{
    public AudioClip[] footstepSounds; // drag your footstep sounds here in the inspector
    public float volume = 1.0f;        // drag the desired volume level here in the inspector
    private AudioSource audioSource;
    private FlyBehaviour flyBehaviour; // Reference to the FlyBehaviour script

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("footstepAudioSource").GetComponent<AudioSource>();
        flyBehaviour = GetComponent<FlyBehaviour>(); // Get the FlyBehaviour script attached to this object
    }

    // This function will be called by the animation event
    public void PlayFootstepSound()
    {
        // Only play the sound if the player is not flying
        if (!flyBehaviour.IsFlying())
        {
            // Choose a random footstep sound
            AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(clip, volume);  // play the sound with the desired volume level
        }
    }
}
