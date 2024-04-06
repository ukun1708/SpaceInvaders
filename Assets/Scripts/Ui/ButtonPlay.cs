using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class ButtonPlay : MonoBehaviour
{
    private float value;

    [Inject] private GameManager gameManager;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            gameManager.startGame.Value = true;
            gameManager.win.Value = false;
            gameManager.lose.Value = false;
        });

        gameManager.startGame.Subscribe(startGame =>
        {
            if (startGame == true)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        });
    }

    private void Update()
    {
        value += Time.deltaTime * 8f;

        var y = Mathf.Sin(value) * .2f;

        transform.position = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);
    }
}
