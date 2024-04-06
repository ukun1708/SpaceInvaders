using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class PauseMenu : MonoBehaviour
{
    [Inject] private GameManager gameManager;

    [SerializeField] private GameObject ui;

    private void Start()
    {
        gameManager.pause.Subscribe(pause =>
        {
            if (pause == true)
            {
                ui.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                ui.SetActive(false);
                Time.timeScale = 1f;
            }
        });
    }

    public void ContinueGame()
    {
        gameManager.pause.Value = false;
    }
    public void PauseGame()
    {
        gameManager.pause.Value = true;
    }
}
