using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public CanonButton clickedCanon { get; set; }
    public int Currency { get => currency;
        set
        {
            currency = value;
            this.currencyText.text = currency.ToString() + "<color=lime> $</color>";
        }
    }

    private int currency;
    [SerializeField] private Text currencyText;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject OptionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        Currency = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }

    public void PickCanon(CanonButton canonButton)
    {
        if (Currency >= canonButton.Price) 
        {
            this.clickedCanon = canonButton;
            Hover.Instance.Activate(canonButton.Sprite);
        }
    }
    public void BuyCanon()
    {
        if (Currency >= clickedCanon.Price) 
        {
            Currency -= clickedCanon.Price;
        }
        clickedCanon = null;
    }

    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            Hover.Instance.Deactivate();
        }
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowPauseMenu()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        if (!PauseMenu.activeSelf)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void ShowOptions()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void ShowMain()
    {
        PauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
}
