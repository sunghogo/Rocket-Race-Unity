using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    [SerializeField] private float _reloadTime = 3f;

    [SerializeField] private TextMeshProUGUI _textComponent;

    // Start is called before the first frame update
    void Start()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
        TurnOffText();
    }

    private void TurnOffText() {
        _textComponent.alpha = 0f;
    }

    public void TurnOnText() {
        _textComponent.alpha = 1f;
    }

    public void StartGameOverSequence() {
        TurnOnText();
        StartCoroutine(WaitThenReloadLevel());
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
