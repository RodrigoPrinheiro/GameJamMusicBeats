﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI offbeatText;
    public static GameUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

            return;
        }

        instance = this;
    }

    public void UpdateOffBeatText(float offbeat)
    {
        if (Mathf.Abs(offbeat) > 0.01f)
        {
            offbeatText.color = Color.red;
            offbeatText.text = $"{offbeat:f2} s";
        }
        else
        {
            offbeatText.color = Color.green;
            offbeatText.text = $"{offbeat:f2} s";
        }
    }
}
