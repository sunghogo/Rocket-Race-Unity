using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 200f;
    [SerializeField] public float _movementSpeed = 50f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            RotateLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            RotateRight();
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            RotateUp();
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            RotateDown();
        }
        if (Input.GetKey(KeyCode.Space)) {
            Thrust();
        }
    }
    
    private void RotateLeft() {
        transform.Rotate(Vector3.forward * Time.deltaTime * _rotationSpeed);
    }

    private void RotateRight() {
        transform.Rotate(Vector3.back * Time.deltaTime * _rotationSpeed);
    }

    private void RotateUp() {
        transform.Rotate(Vector3.left * Time.deltaTime * _rotationSpeed);
    }

    private void RotateDown() {
        transform.Rotate(Vector3.right * Time.deltaTime * _rotationSpeed);
    }

    private void Thrust() {
        transform.Translate(Vector3.up * Time.deltaTime * _movementSpeed);
    }
}
