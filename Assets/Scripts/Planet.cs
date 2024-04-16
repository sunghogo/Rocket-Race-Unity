using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private float _reloadTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _gameOver = FindObjectOfType<Canvas>().GetComponentInChildren<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100f);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Star") || other.gameObject.CompareTag("Planet")) {
            Destroy(other.gameObject);
        } else {
            other.gameObject.SetActive(false);
            _gameOver.TurnOnText();
            StartCoroutine(WaitThenReloadLevel());
        }
    }

    IEnumerator WaitThenReloadLevel() {
        yield return new WaitForSeconds(_reloadTime);
        ReloadLevel();
    }
    private void ReloadLevel() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
