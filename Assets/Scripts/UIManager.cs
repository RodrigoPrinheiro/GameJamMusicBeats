using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Animator        menuSlide;
    [SerializeField] private AudioClip       menuSound;

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
        if (menuSlide) menuSlide.SetTrigger("Back");
        AudioManager.instance.PlaySound(menuSound, 0.1f, 1);
        currentMenu = 0;
    }

    public void SongPick()
    {
        if (currentMenu == 1) return;
        if (menuSlide) menuSlide.SetTrigger("PickSongMenu");
        AudioManager.instance.PlaySound(menuSound, 0.1f, 1);
        currentMenu = 1;
    }

    public void ACDCSong()
    {
        SceneManager.LoadScene("ACDC-TNT");
    }

    public void SuperMarioSong()
    {
        SceneManager.LoadScene("SuperMario");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
