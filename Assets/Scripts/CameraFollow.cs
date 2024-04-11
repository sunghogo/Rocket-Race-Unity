using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed; 
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Transform _rocketTransform;

    private Vector3 offset;

    void Start()
    {
        _rocket = FindObjectOfType<Rocket>();
        _rocketTransform = _rocket.transform;
        _followSpeed = _rocket.GetComponent<Rocket>()._movementSpeed;

        offset = transform.position; // Set offset in Inspector
    }

    // Last Update occurs every frame after Update()
    void LateUpdate()
    {
        Vector3 newCameraPosition = _rocketTransform.position + offset;

        transform.position = Vector3.Slerp(transform.position, newCameraPosition, _followSpeed * Time.deltaTime); // Smoothly move the camera to the new position

        transform.LookAt(_rocketTransform.position); // Make camera look at new rocket position
    }
}
