using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    void Update() {
        transform.Rotate(Vector3.up * Time.deltaTime * 100f);
    }

    void OnCollisionEnter(Collision other) {
        Debug.Log("Colliding");
        Destroy(gameObject);
    }
}
