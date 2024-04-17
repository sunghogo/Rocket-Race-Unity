using UnityEngine;
using TMPro;

public class Controls : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textComponent;

    void Start()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
        TurnOnText();
    }

    public void TurnOffText() {
        _textComponent.alpha = 0f;
    }

    private void TurnOnText() {
        _textComponent.alpha = 1f;
    }
}
