using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] private float _xBoundary = 50f;
    [SerializeField] private float _yBoundary = 50f;
    [SerializeField] private float _zBoundary = 50f;
    [SerializeField] private float _spawnTime = 10f;
    [SerializeField] private float _maxScale = 6f;
    [SerializeField] private Planet _planetObject;
    
    // Start is called before the first frame update
    void Start()
    {
        _planetObject = FindObjectOfType<Planet>();
        StartCoroutine(SpawnPlanetsForever());
    }

    private IEnumerator SpawnPlanetsForever() {
        while (true) {
            GeneratePlanet();
            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private void GeneratePlanet() {
        Planet planet = Instantiate(_planetObject, GenerateRandomPosition(_xBoundary, _yBoundary, _zBoundary), Quaternion.identity);
        planet.transform.localScale = GenerateRandomScale(_maxScale);
    }

    private Vector3 GenerateRandomPosition(float x, float y, float z) {
        return new Vector3(Random.Range(-x, x), Random.Range(-y, y), Random.Range(-z, z));
    }

    private Vector3 GenerateRandomScale(float maxScale) {
        float scale = Random.Range(maxScale * 0.5f , maxScale);
        return new Vector3(scale, scale, scale);
    }
}
