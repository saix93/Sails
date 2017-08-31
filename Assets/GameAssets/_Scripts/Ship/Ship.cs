using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipMovement))]
public class Ship : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private float _movementSpeed = 1;
    [SerializeField]
    private string _shipName;
    [SerializeField]
    private GameManager.EFactionName _faction;

    public float MovementSpeed
    {
        get
        {
            return _movementSpeed;
        }
        private set
        {
            _movementSpeed = value;
        }
    }

    public string ShipName
    {
        get
        {
            return _shipName;
        }
        private set
        {
            _shipName = value;
        }
    }

    public Faction Faction
    {
        get; private set;
    }

    public bool IsMoving
    {
        get; set;
    }

    private ShipMovement _sm;

    private Vector3 targetPosition;

    private ShipCanvas _sc;

    private Dictionary<GameManager.EProductName, Product> _products;

    /* Metodos */

    private void Awake()
    {
        _sm = this.GetComponent<ShipMovement>();
        _sc = this.GetComponentInChildren<ShipCanvas>();
    }

    private void Start()
    {
        _products = GameManager.GetBasicProducts();
    }

    private void Update()
    {
        Faction = GameManager.GetFaction(_faction);

        if (IsMoving)
        {
            _sm.MoveShip(targetPosition);
        }

        // Si la facción del barco es de un player
        if (Faction == GameManager.PlayerFaction && this == GameManager.SelectedPlayerShip && Input.GetButtonDown("RightClick"))
        {
            targetPosition = GameManager.GetMousePosition();

            int layerMask = 1 << LayerMask.NameToLayer("Towns");

            Collider2D[] colArray = Physics2D.OverlapPointAll(GameManager.GetMousePosition(), layerMask);

            foreach (Collider2D col in colArray)
            {
                if (col.gameObject.layer == LayerMask.NameToLayer("Towns"))
                {
                    // Si se hace click en una ciudad
                    Town town = col.GetComponent<Town>();

                    targetPosition = col.transform.position;
                    targetPosition.z = this.transform.position.z;

                    // Si el barco ya está en la ciudad...
                    if (town.IsShipInTown(this))
                    {
                        // ... se abre ventana de comercio
                        Commerce.ShowCommerce(town, this);
                    }
                }
            }

            IsMoving = true;
        }
    }

    private void OnGUI()
    {
        _sc.UpdateShipFaction(Faction);
    }
}
