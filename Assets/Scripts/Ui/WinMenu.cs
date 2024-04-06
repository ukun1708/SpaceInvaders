using UnityEngine;
using Zenject;
using UniRx;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private GameObject ui;

    [Inject] private GameManager gameManager;

    private void Start()
    {
        gameManager.win.Subscribe(win =>
        {
            if (win == true)
            {
                ui.SetActive(true);
            }
            else
            {
                ui.SetActive(false);
            }
        });
    }
}
