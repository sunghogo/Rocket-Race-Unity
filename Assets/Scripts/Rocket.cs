using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float _movementSpeed = 30f;
    [SerializeField] private float _rotationSpeed = 300f;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Star")) EventManager.RocketCollideStar(other.gameObject);
        else if (other.gameObject.CompareTag("Planet")) EventManager.RocketCollidePlanet(gameObject);
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
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
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
