using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    private void Start()
    {
        // kita langsung hapus game objectnya setelah 1 detik
        Destroy(gameObject, 1.0f);
    }
}