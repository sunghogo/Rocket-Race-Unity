using UnityEngine;

public class Planet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100f);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Star") || other.gameObject.CompareTag("Planet")) EventManager.PlanetColideNotRocket(other.gameObject);
    }


}
