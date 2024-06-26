using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private float _score = 0;
    [SerializeField] private TextMeshProUGUI _textComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
        _textComponent.text = $"Score: {_score}";
    }

    // Update is called once per frame
    void Update()
    {
        _textComponent.text = $"Score: {_score}";
    }

    public void IncrementScore() {
        _score++;
    }
}
