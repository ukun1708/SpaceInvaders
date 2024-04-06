using TMPro;
using UnityEngine;
using Zenject;
using UniRx;

public class Wave : MonoBehaviour
{
    [Inject] private GameManager gameManager;

    private TMP_Text waveText;
    private void Awake() => waveText = GetComponent<TMP_Text>();
    private void Start()
    {
        gameManager.waveCount.Subscribe(waveCount =>
        {
            waveText.text = "Wave: " + waveCount.ToString();
        });
    }
}
