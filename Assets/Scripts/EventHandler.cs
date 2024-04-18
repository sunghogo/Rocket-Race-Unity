using System;
using System.Threading;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private Controls _controls;

    public static Vector3 BoundarySize =  new Vector3(125f, 125f, 125f);
    public static event Action GetStar;
    public static event Action GameOver;

    // Start is called before the first frame update
    void Start()
    {
        var canvas = FindObjectOfType<Canvas>(); 
        _score = canvas.GetComponentInChildren<Score>();   
        _gameOver = canvas.GetComponentInChildren<GameOver>();
        _controls = canvas.GetComponentInChildren<Controls>();


        ClearEvents(); // static events will persist so must be cleared

        GetStar += _score.IncrementScore;
        GetStar += _controls.TurnOffText;
        GameOver += _gameOver.StartGameOverSequence;
        GameOver += _controls.TurnOffText;
    }

    public static void RocketCollideStar(GameObject star) {
        GetStar?.Invoke();
        Destroy(star);
    }

    public static void RocketCollidePlanet() {
        GameOver?.Invoke();
    }

    public static void PlanetColideNotRocket (GameObject other) {
        Destroy(other);
    }

    private void ClearEvents() {
        GetStar = null;
        GameOver = null;
    }
}
