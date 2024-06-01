using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject CreditsMenu;
    [SerializeField] private GameObject Back;
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        LevelManager.currentLevel = data.level;
        GameManager.currency = data.currency;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowCredits()
    {
        CreditsMenu.SetActive(true);
    }
    public void HideCredits()
    {
        CreditsMenu.SetActive(false);
    }
}
