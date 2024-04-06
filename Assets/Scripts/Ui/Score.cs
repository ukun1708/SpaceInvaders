using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using UniRx;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [Inject] GameManager gameManager;

    private TMP_Text scoreText;
    private void Awake() => scoreText = GetComponent<TMP_Text>();
    private void Start()
    {
        gameManager.score.Subscribe(score =>
        {
            scoreText.text = "Score: " + score.ToString();
        });
    }
}
