using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    /*In order to make a metronome you need the number of beats each second
     * if 60bpm is 1 beat per second (60 / 60 = 1) then, 60/songBPM = interval between beats.*/
    [SerializeField] private AudioClip metronomeSound;

    private float songBPM;
    private float callBeat;
    private float timeOfPress;
    private bool  songStarted;

    public float SongBeat
    {
        get
        {
            return 60 / songBPM;
        }

        set
        {
            songBPM = value;
        }
    }

    private void Start()
    {
        ResetSongBeat();
        songStarted = false;
    }

    public void ResetSongBeat()
    {
        callBeat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
        callBeat += Time.deltaTime;
        if (callBeat > SongBeat)
        {
            PlayMetronomeSound();
            callBeat = 0;
            OnBeat();
        }
    }

    private void PlayMetronomeSound()
    {
        if (songStarted) return;
        AudioManager.instance.PlaySound(metronomeSound, 0.5f, 1);
    }

    private void OnBeat()
    {
        // Get the pressed time offset
        float beatTimeOffset;
        beatTimeOffset = timeOfPress - Time.time;

        // Send information to UI with the value of the offset
        UIManager.instance.UpdateBeatOffset(beatTimeOffset);
    }

    private void CheckForInput()
    {
        // beat stuff, check if player tapped on the screen
#if (UNITY_ANDROID)
        if (Input.touches.Length > 0)
        {
            timeOfPress = Time.time;
        }
#else
        if (Input.GetButtonDown("Jump"))
        {
            timeOfPress = Time.time;
        }
#endif
    }
}
