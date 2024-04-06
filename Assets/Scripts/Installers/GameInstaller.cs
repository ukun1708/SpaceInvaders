using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameController gameController;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private VfxManager vfxManager;
    [SerializeField] private BonusManager bonusManager;
    public override void InstallBindings()
    {
        Container.Bind<GameController>().FromInstance(gameController);
        Container.Bind<GameManager>().FromInstance(gameManager);
        Container.Bind<WaveManager>().FromInstance(waveManager);
        Container.Bind<VfxManager>().FromInstance(vfxManager);
        Container.Bind<BonusManager>().FromInstance(bonusManager);
    }
}