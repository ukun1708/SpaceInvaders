using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bonus : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Inject] private VfxManager vfxManager;

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    private void Update() => transform.Translate(Vector3.back * 10f * Time.deltaTime);

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ship>())
        {
            vfxManager.PlayVFX(VfxManager.VfxType.destroy, transform.position);
            Destroy(gameObject);
        }
    }
}
