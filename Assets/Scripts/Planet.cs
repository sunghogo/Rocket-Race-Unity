using UnityEngine;

public class Planet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100f);
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("Star") || other.gameObject.CompareTag("Planet")) EventManager.PlanetColideNotRocket(other.gameObject);
    }


}
