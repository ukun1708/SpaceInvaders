using DG.Tweening;
using UnityEngine;
using Zenject;
using UniRx;

public class Ship : MonoBehaviour
{
    [Inject] private GameController gameController;
    [Inject] private GameManager gameManager;

    [SerializeField] Transform model;

    private Tween rotateTween;

    private bool ready;

    private void Start()
    {
        Subscribes();
    }
    private void Subscribes()
    {
        gameManager.startGame.Subscribe(startGame =>
        {
            if (startGame == true)
            {
                ready = true;
            }
            else
            {
                ready = false;
                transform.DOMove(Vector3.zero, .25f).SetEase(Ease.OutBack);
                rotateTween.Kill();
                rotateTween = model.DORotate(Vector3.zero, .25f).SetEase(Ease.OutBack);
            }
        });
    }

    private void Update()
    {
        if (ready == true)
        {
            MoveShip(gameController.joystick, gameController.shipMaxSpeed);
        }
    }
    public void MoveShip(DynamicJoystick joystick, float maximumSpeed)
    {
        float hor = joystick.Horizontal;
        float ver = joystick.Vertical;

        Vector3 movedirection = new(hor, 0f, ver);

        float inputMagnitude = Mathf.Clamp01(movedirection.magnitude);
        float speed = inputMagnitude * maximumSpeed;
        movedirection.Normalize();

        Vector3 velocity = movedirection * speed;

        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            rotateTween.Kill();
        }
        if (Input.GetMouseButton(0))
        {
            model.rotation = Quaternion.Euler(velocity.z, 0f, -velocity.x * 3f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            rotateTween.Kill();
            rotateTween = model.DORotate(Vector3.zero, .25f).SetEase(Ease.OutBack);
        }
    }
}
