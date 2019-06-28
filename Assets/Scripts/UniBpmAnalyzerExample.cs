/*
UniBpmAnalyzer
Copyright (c) 2016 WestHillApps (Hironari Nishioka)
This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/

using UnityEngine;

public class UniBpmAnalyzerExample : MonoBehaviour
{
    public AudioClip targetClip;

    public int CurrentClipBPM { get; private set; }

    private Metronome metronome;

    private void Start()
    {
        CurrentClipBPM = UniBpmAnalyzer.AnalyzeBpm(targetClip);
        if (CurrentClipBPM <= 0)
        {
            Debug.LogError("AudioClip is null.");
            return;
        }

        metronome = GetComponent<Metronome>();
        metronome.StartBeat(CurrentClipBPM);
    }
}
