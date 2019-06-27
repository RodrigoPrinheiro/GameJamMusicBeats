using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    /*In order to make a metronome you need the number of beats each second
     * if 60bpm is 1 beat per second (60 / 60 = 1) then, 60/songBPM = interval between beats.*/
    [SerializeField] private AudioClip metronomeSound;

    private float callBeat;
    private float timeOfPress;
    private bool  songStarted;

    private void Start()
    {
        callBeat = 0;
        songStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
        if (callBeat >= 60 / UniBpmAnalyzerExample.instance.CurrentClipBPM)
        {
            PlayMetronomeSound();
            callBeat = 0;
            OnBeat();
        }
        else
            callBeat += Time.deltaTime;
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
            songStarted = true;
        }
#else
        if (Input.GetButtonDown("Jump"))
        {
            timeOfPress = Time.time;
            songStarted = true;
        }
#endif
    }
}
