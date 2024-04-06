using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private GameObject bonusPrefab;
    [SerializeField] private Sprite[] sprites;

    [Inject] private DiContainer container;

    public void CreateBonus(Vector3 createPos)
    {
        var chance = Random.Range(0, 10);

        if (chance == 5)
        {
            var value = Random.Range(0, sprites.Length);

            var bonus = container.InstantiatePrefab(bonusPrefab, createPos, Quaternion.identity, null);

            Bonus _bonus = bonus.GetComponent<Bonus>();

            switch (value)
            {
                case 0:
                    _bonus.SetSprite(sprites[value]);
                    break;
                case 1:
                    _bonus.SetSprite(sprites[value]);
                    break;
                case 2:
                    _bonus.SetSprite(sprites[value]);
                    break;
            }
        }
    }
}
