using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonRestart : MonoBehaviour
{
    private Button button;

    [Inject] private GameManager gameManager;
    [Inject] private WaveManager waveManager;
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            gameManager.startGame.Value = false;
            gameManager.pause.Value = false;

            waveManager.DestroyEnemies();
        });
    }
}
