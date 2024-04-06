using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoveLimiter : MonoBehaviour
{
    [Inject] private GameController gameController;
    void Update()
    {
        if (transform.position.x > gameController.shipLimiterX)
        {
            transform.position = new Vector3(gameController.shipLimiterX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -gameController.shipLimiterX)
        {
            transform.position = new Vector3(-gameController.shipLimiterX, transform.position.y, transform.position.z);
        }
        if (transform.position.z > gameController.shipLimiterZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, gameController.shipLimiterZ);
        }
        if (transform.position.z < -gameController.shipLimiterZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -gameController.shipLimiterZ);
        }
    }
}
