using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Metronome : MonoBehaviour
{
    /*In order to make a metronome you need the number of beats each second
     * if 60bpm is 1 beat per second (60 / 60 = 1) then, 60/songBPM = interval between beats.*/
    [SerializeField] private AudioClip metronomeSound;
    public AudioClip targetClip;
    public UnityEvent updateCombo;

    private float timeOfPress;
    private bool  songStarted;
    private float songBPM;
    private bool  firstInputTaken;

    private int currentBPM;

    float beatTimeOffset;
    float lastBeatOffset;
    public int combo;
    private void Start()
    {
        currentBPM = UniBpmAnalyzer.AnalyzeBpm(targetClip);
        if (currentBPM <= 0)
        {
            Debug.LogError("AudioClip is null.");
            return;
        }
        StartBeat(currentBPM);
    }

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
        AudioManager.instance.PlaySound(targetClip);
    }

    public void StopBeat()
    {
        StopCoroutine(PlayBeatCoroutine());
    }

    private void OnBeat()
    {
        if (!firstInputTaken)
        {
            GameUI.instance.UpdateOffBeatText(songBPM);
        }
        else
        {
            firstInputTaken = false;

            lastBeatOffset = beatTimeOffset;

            // Get the pressed time offset
            beatTimeOffset = Time.time - timeOfPress;
            beatTimeOffset -= songBPM / 2;

            if (Mathf.Abs(lastBeatOffset - beatTimeOffset) < 0.01f)
            {
                combo++;
            }
            else
                combo = 0;

            updateCombo.Invoke();
            // Send information to UI with the value of the offset
            GameUI.instance.UpdateOffBeatText(beatTimeOffset);
        }
    }

    private void CheckForInput()
    {
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
        float time = 0;
        while (true)
        {
            while (time < songBPM + songBPM / 2)
            {
                time += Time.deltaTime;
                yield return null;
            }

            time -= songBPM;
            if (songStarted)
            {
                OnBeat();
            }

            if (!songStarted)
                AudioManager.instance.PlaySound(metronomeSound, 0.5f, 1);
        }
    }
}
