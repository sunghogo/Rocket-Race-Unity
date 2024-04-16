using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100f);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Star") || (other.gameObject.CompareTag("Planet"))) {
            Destroy(other.gameObject);
        } else {
            other.gameObject.SetActive(false);
        }
    }
}