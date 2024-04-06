using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    public float speed;

    [Inject] private VfxManager vfxManager;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
        {
            damagable.ApplyDamage();

            vfxManager.PlayVFX(VfxManager.VfxType.destroy, transform.position);

            Destroy(gameObject);
        }
    }
}
