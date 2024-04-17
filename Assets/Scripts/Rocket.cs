using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float _movementSpeed = 30f;
    [SerializeField] private float _rotationSpeed = 300f;
    [SerializeField] private AudioClip _thrustClip;
    [SerializeField] private AudioClip _explosionClip;
    [SerializeField] private AudioClip _starClip;
    private AudioSource _audioSource;
    private bool _inputOn = true;


    void Start() {
        _audioSource = GetComponent<AudioSource>(); 
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Star")) GetStar(other.gameObject);
        else if (other.gameObject.CompareTag("Planet")) Crash();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputOn) {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) RotateLeft();
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) RotateRight();
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) RotateUp();
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) RotateDown();

            if (Input.GetKey(KeyCode.Space)) Thrust();
            else StopThrust();
        }   

        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
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
        if (!_audioSource.isPlaying) _audioSource.PlayOneShot(_thrustClip);
        transform.Translate(Vector3.up * Time.deltaTime * _movementSpeed);
    }

    private void StopThrust() {
        if (_audioSource.isPlaying) _audioSource.Stop();
    }

    private void GetStar(GameObject star) {
        _audioSource.PlayOneShot(_starClip);
        EventManager.RocketCollideStar(star);
    }

    private void Crash() {
        _inputOn = false;
        DisableAllChildMeshes();
        _audioSource.Stop();
        _audioSource.PlayOneShot(_explosionClip);
        EventManager.RocketCollidePlanet();
    }

    private void DisableAllChildMeshes() {
        foreach (var childMesh in GetComponentsInChildren<MeshRenderer>()) {
            childMesh.enabled = false;
        }
    }
}
