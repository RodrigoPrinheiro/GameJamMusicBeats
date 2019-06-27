using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private Animator menuSlide;
    private int currentMenu;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

            return;
        }

        instance = this;
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
