using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _startButton;
    [SerializeField] LoadingScreen screen;
    private Loading loading;
    void Start()
    {
        loading = new Loading("Main");
        _startButton.onClick.AddListener(StartNewGame);
        loading.OnFrameOverEvent += screen.UpdateProgressBar;
    }
    private void StartNewGame()
    {
        screen.gameObject.SetActive(true);
        loading.StartNewGame();
        this.gameObject.SetActive(false);
    }

}
