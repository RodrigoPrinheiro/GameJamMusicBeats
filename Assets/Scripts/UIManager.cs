﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator        menuSlide;
    [SerializeField] private TextMeshProUGUI timeBeat;

    private int currentMenu;

    public static UIManager instance;
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
        currentMenu = 0;
    }
    public void MainMenu()
    {
        if (currentMenu == 0) return;
        menuSlide.SetTrigger("Back");
        currentMenu = 0;
    }

    public void SongPick()
    {
        if (currentMenu == 1) return;
        menuSlide.SetTrigger("PickSongMenu");
        currentMenu = 1;
    }

    public void StartSong()
    {

    }

    public void UpdateBeatOffset(float timeOffset)
    {
        if (Mathf.Abs(timeOffset) > 0.01f)
        {
            // write in some red text the offset
            timeBeat.color = Color.white;
            timeBeat.text = $"{timeOffset:f2}";
        }
        else
        {
            // right in green 0.0
            timeBeat.color = Color.green;
            timeBeat.text = $"{timeOffset:f2}";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}