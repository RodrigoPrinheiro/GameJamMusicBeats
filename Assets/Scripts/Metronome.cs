using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    /*In order to make a metronome you need the number of beats each second
     * if 60bpm is 1 beat per second (60 / 60 = 1) then, 60/songBPM = interval between beats.*/
    [SerializeField] private AudioClip metronomeSound;

    private float timeOfPress;
    private bool  songStarted;
    private float songBPM;
    private bool  firstInputTaken;
    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }

    public void StartBeat(float BPM)
    {
        firstInputTaken = false;
        songStarted = false;
        songBPM = (60f / BPM);
        StartCoroutine(PlayBeatCoroutine());
    }

    public void StopBeat()
    {
        StopCoroutine(PlayBeatCoroutine());
    }

    private void OnBeat()
    {
        firstInputTaken = false;

        // Get the pressed time offset
        float beatTimeOffset;
        beatTimeOffset = Time.time - timeOfPress;

        // Send information to UI with the value of the offset
        GameUI.instance.UpdateOffBeatText(beatTimeOffset);
    }

    private void CheckForInput()
    {
        Debug.Log(firstInputTaken);
        if (firstInputTaken) return;
        // beat stuff, check if player tapped on the screen
#if (UNITY_ANDROID)
        if (Input.touches.Length > 0)
        {
            timeOfPress = Time.time;
            songStarted = true;
            firstInputTaken = true;

        }
#else
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            timeOfPress = Time.time;
            songStarted = true;
            firstInputTaken = true;
        }
#endif
    }

    private IEnumerator PlayBeatCoroutine()
    {
        while (true)
        {
            if (!songStarted)
                AudioManager.instance.PlaySound(metronomeSound, 0.5f, 1);
            OnBeat();
            yield return new WaitForSeconds(songBPM);
        }
    }
}
