using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxTimeHold;
    public float maxForce;

    private Renderer renderer;
    private bool isHold;

    private void Start()
    {
        isHold = false;
        // Contoh debug log untuk menunjukkan bahwa Start() telah dipanggil
    
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
            // Contoh debug log untuk menunjukkan saat masuk ke dalam OnCollisionStay
          
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
            // Debug log untuk menunjukkan kapan ReadInput dipanggil
            Debug.Log("ReadInput called.");
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);
            // Debug log untuk menampilkan nilai force saat ini
            Debug.Log("Current force: " + force);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;

        // Debug log untuk menunjukkan bahwa StartHold telah selesai
        Debug.Log("StartHold finished.");
    }
}
