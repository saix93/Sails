using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Ship _ship;

    [SerializeField]
    private Transform _model;

    /* Metodos */

    private void Awake()
    {
        _ship = this.GetComponent<Ship>();
    }

    /// <summary>
    /// Mueve el barco hacia un punto concreto
    /// </summary>
    /// <param name="to"></param>
    public void MoveShip(Vector3 to)
    {
        // Ajusta la rotación del barco hacia el punto donde debe moverse
        Vector3 diff = to - this.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        _model.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        // Mueve el barco hacia la dirección donde debe moverse
        this.transform.position += diff * _ship.MovementSpeed * Time.deltaTime;

        // Si el barco está en la posición correcta, para de moverse
        float distance = Vector3.Distance(this.transform.position, to);

        if (distance < GameManager.ShipMovementThreshold)
        {
            this.transform.position = to;
            _ship.IsMoving = false;
        }
    }
}
