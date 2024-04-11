using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 3f;
    [SerializeField] private Star _starObject;

    // Start is called before the first frame update
    void Start()
    {
        _starObject = FindObjectOfType<Star>();
        StartCoroutine(SpawnStarForever());
    }

    private IEnumerator SpawnStarForever() {
        while (true) {
            GenerateStar();
            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private void GenerateStar() {
        Instantiate(_starObject, GenerateRandomPosition(50f, 50f, 50f), Quaternion.identity);
    }

    private Vector3 GenerateRandomPosition(float x, float y, float z) {
        return new Vector3(Random.Range(-x, x), Random.Range(-y, y), Random.Range(-z, z));
    }
}
