using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDCamera : MonoBehaviour
{
    [SerializeField]
    private float _cameraSpeed;

    private float _horizontalAxis;
    private float _verticalAxis;

    private void Update()
    {
        _horizontalAxis = Input.GetAxis("Horizontal");
        _verticalAxis = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = this.transform.position;
        newPosition.x += _horizontalAxis * _cameraSpeed * Time.deltaTime;
        newPosition.y += _verticalAxis * _cameraSpeed * Time.deltaTime;

        this.transform.position = newPosition;
    }
}
