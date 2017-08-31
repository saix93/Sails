using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    private Camera _camera;
    private Vector3 dragOrigin;

    private void Awake()
    {
        _camera = this.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("MiddleClick"))
        {
            dragOrigin = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            dragOrigin = _camera.ScreenToWorldPoint(dragOrigin);
        }

        if (Input.GetButton("MiddleClick"))
        {
            Vector3 currentPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            currentPos = _camera.ScreenToWorldPoint(currentPos);
            Vector3 movePos = dragOrigin - currentPos;
            transform.position += movePos;
        }
    }
}
