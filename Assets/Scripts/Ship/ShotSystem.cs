using UnityEngine;
using Zenject;
using UniRx;
using System;

public class ShotSystem : MonoBehaviour
{
    [Inject] private DiContainer _container;
    [Inject] private GameManager gameManager;
    [Inject] private VfxManager vfxManager;

    private bool shooting;

    [SerializeField] private float rateShooting;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform muzzle;

    private float startRate;
    private void Start()
    {
        startRate = rateShooting;
        gameManager.startGame.Subscribe(startGame =>
        {
            if (startGame == true)
            {
                rateShooting = 1f;
                shooting = true;
            }
            else
            {
                shooting = false;
            }
        });
    }

    private void Update()
    {
        if (shooting == true) 
        { 
            rateShooting -= Time.deltaTime;

            if (rateShooting <= 0f)
            {
                rateShooting = startRate;
                Shot();
            }
        }
    }

    private void Shot()
    {
        vfxManager.PlayVFX(VfxManager.VfxType.shot, muzzle.position);

        var currentBullet = _container.InstantiatePrefab(bulletPrefab.gameObject, muzzle.position, Quaternion.identity, null);
    }
}
