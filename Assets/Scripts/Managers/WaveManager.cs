using UnityEngine;
using Zenject;
using UniRx;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private int enemyinRow = 5;
    [SerializeField] private Transform startPos;

    [Inject] private GameManager gameManager;

    [Inject] DiContainer container;

    [SerializeField] private float offset;

    public List<GameObject> enemies = new();

    private void Start()
    {
        gameManager.startGame.Subscribe(startGame =>
        {
            if (startGame == true)
            {
                CreateEnemies();
            }
        });
    }

    public void DestroyEnemies()
    {
        GameObject[] currentEnemies = enemies.ToArray();
        enemies.Clear();

        if (currentEnemies != null)
        {
            for (int i = 0; i < currentEnemies.Length; i++)
            {
                Destroy(currentEnemies[i]);
            }
        }
    }

    private async void CreateEnemies()
    {
        for (int x = 0; x < enemyinRow; x++)
        {
            for (int z = 0; z < enemyinRow; z++)
            {
                CreatePieces(x, z);

                await UniTask.Delay(5);
            }
        }
    }

    private void CreatePieces(int x, int z)
    {
        var currentEnemy = container.InstantiatePrefab(enemy.gameObject);
        enemies.Add(currentEnemy);
        currentEnemy.transform.position = startPos.position + new Vector3(offset * x - enemyinRow + 1, 0f, offset * z - enemyinRow);
        currentEnemy.transform.localScale = Vector3.zero;
        currentEnemy.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
    }

    public void CheckEnemies()
    {
        if (enemies.Count == 0)
        {
            gameManager.win.Value = true;
            gameManager.startGame.Value = false;
            gameManager.waveCount.Value++;
        }
    }
}
