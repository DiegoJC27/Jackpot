using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance == this)
            Destroy(this);

        else
            Instance = this;
    }

    private void Start()
    {
        player = GetComponent<AudioSource>();
    }

    AudioSource player;

    public void PlaySound(AudioClip sound) {
        player.PlayOneShot(sound);
    }

    //public void PlayMusic(AudioClip music)
    //{
    //    player.Play(music);
    //}
}
