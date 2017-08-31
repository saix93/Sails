using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField]
    private float _minZoom = 1;
    [SerializeField]
    private float _maxZoom = 6;
    [SerializeField]
    private float _zoomSpeed = 3;

    private Camera _camera;

    private void Awake()
    {
        _camera = this.GetComponent<Camera>();
    }

    private void Update()
    {
        float scrollWheelAxis = Input.GetAxis("Mouse ScrollWheel");

        _camera.orthographicSize -= scrollWheelAxis * _zoomSpeed;
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minZoom, _maxZoom);
    }
}
