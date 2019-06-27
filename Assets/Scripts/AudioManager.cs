using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private List<AudioSource> sources;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        sources = new List<AudioSource>();
        GetComponentsInChildren<AudioSource>(true, sources);
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f, float pitch = 1.0f)
    {
        foreach (var a in sources)
        {
            if (!a.isPlaying)
            {
                a.clip = clip;
                a.pitch = pitch;
                a.volume = volume;
                a.Play();

                return;
            }
        }

        GameObject newAudioSource = new GameObject();
        newAudioSource.name = "AudioSource";
        newAudioSource.transform.parent = transform;
        AudioSource audioSource = newAudioSource.AddComponent<AudioSource>();
        sources.Add(audioSource);

        // Play Clip
        audioSource.clip = clip;
        audioSource.pitch = pitch;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
