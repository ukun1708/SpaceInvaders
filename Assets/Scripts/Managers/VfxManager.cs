using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxManager : MonoBehaviour
{
    [SerializeField] private GameObject[] particles;

    public void PlayVFX(VfxType vfxType, Vector3 createPosition)
    {
        GameObject particle = Instantiate(particles[(int)vfxType], createPosition, Quaternion.identity);

        particle.GetComponent<ParticleSystem>().Play();

        Destroy(particle, 1f);
    }
    public enum VfxType
    {
        destroy,
        shot
    }
}
