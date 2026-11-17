using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
