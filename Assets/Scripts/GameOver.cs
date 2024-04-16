using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
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
}
