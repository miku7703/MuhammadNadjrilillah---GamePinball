using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject vfxAudioSource;


    public void PlayVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxAudioSource, spawnPosition, Quaternion.identity);
    }

}
