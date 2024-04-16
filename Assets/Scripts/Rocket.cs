using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Rocket : MonoBehaviour
{
    public float _movementSpeed = 30f;
    [SerializeField] private float _rotationSpeed = 300f;

    [SerializeField] private Score _score;

    
    // Start is called before the first frame update
    void Start()
    {
        _score = FindObjectOfType<Score>();
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Star")) {
            Destroy(other.gameObject);
            _score.IncrementScore();
        }
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
