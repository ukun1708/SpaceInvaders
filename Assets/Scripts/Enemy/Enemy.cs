using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private Transform model;

    private float value;

    [Inject] private WaveManager waveManager;
    [Inject] private GameManager gameManager;
    [Inject] private BonusManager bonusManager;

    private void Update()
    {
        value += Time.deltaTime * 8f;

        var y = Mathf.Sin(value) * Time.deltaTime;

        model.localPosition = new Vector3(model.localPosition.x, model.localPosition.y + y, model.localPosition.z);
    }

    public void ApplyDamage()
    {
        waveManager.enemies.Remove(gameObject);
        waveManager.CheckEnemies();
        gameManager.score.Value++;
        bonusManager.CreateBonus(transform.position);
        Destroy(gameObject);
    }
}
