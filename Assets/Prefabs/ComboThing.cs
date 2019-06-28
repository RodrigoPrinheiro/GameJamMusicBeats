using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboThing : MonoBehaviour
{
    public Metronome metronome;
    public ComboText textprefab;
    public Transform holder;
    public float lifeTime = 5;


    public void updateCombo()
    {
        if (!metronome)
            return;

        var txt = Instantiate(textprefab, holder);
        txt.SetCombo(metronome.combo);
        Destroy(txt.gameObject, lifeTime);
    }
}
