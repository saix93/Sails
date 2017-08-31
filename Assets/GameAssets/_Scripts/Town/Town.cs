using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Town : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private string _townName;
    [SerializeField]
    private float _detectionRadius = 0.5f;
    [SerializeField]
    private GameManager.EFactionName _faction;

    private Dictionary<GameManager.EProductName, Product> _products;

    private TownCanvas _tc;

    public string TownName
    {
        get
        {
            return _townName;
        }
        private set
        {
            _townName = value;
        }
    }

    public Faction Faction
    {
        get; private set;
    }

    private List<Ship> _shipList = new List<Ship>();

    /* Metodos */

    private void Awake()
    {
        _tc = this.GetComponentInChildren<TownCanvas>();
    }

    private void Start()
    {
        _products = GameManager.GetBasicProducts();
    }

    private void Update()
    {
        Faction = GameManager.GetFaction(_faction);

        int layerMask = 1 << LayerMask.NameToLayer("Ships");
        Collider2D[] currentFrameColArray = Physics2D.OverlapCircleAll(this.transform.position, _detectionRadius, layerMask);

        Ship[] _currentFrameShipArray = new Ship[currentFrameColArray.Length];

        for (int i = 0; i < currentFrameColArray.Length; i++)
        {
            if (currentFrameColArray[i] && !currentFrameColArray[i].isTrigger)
            {
                Ship ship = currentFrameColArray[i].GetComponent<Ship>();
                _currentFrameShipArray[i] = ship;
                if (!_shipList.Contains(ship))
                {
                    AddShipToList(ship);
                }
            }
        }

        for (int i = 0; i < _shipList.Count; i++)
        {
            if (!_currentFrameShipArray.Contains(_shipList[i]))
            {
                RemoveShipFromList(_shipList[i]);
                continue;
            }
        }

        /*  DEBUG  */
        if (_shipList.Count > 0)
        {
            Debug.Log("LISTA DE BARCOS EN LA CIUDAD DE " + TownName);
            foreach (Ship s in _shipList)
            {
                Debug.Log("Nombre del barco: " + s.GetComponent<Ship>().ShipName);
            }
        }
        /*  DEBUG  */
    }

    private void OnGUI()
    {
        _tc.UpdateShipNumber(_shipList.Count);
        _tc.UpdateTownFaction(Faction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(this.transform.position, _detectionRadius);
    }

    private void AddShipToList(Ship ship)
    {
        ship.GetComponentInChildren<SpriteRenderer>().enabled = false;
        ship.GetComponentInChildren<Canvas>().enabled = false;
        _shipList.Add(ship);
    }

    private void RemoveShipFromList(Ship ship)
    {
        ship.GetComponentInChildren<SpriteRenderer>().enabled = true;
        ship.GetComponentInChildren<Canvas>().enabled = true;
        _shipList.Remove(ship);
    }

    public bool IsShipInTown(Ship ship)
    {
        return _shipList.Contains(ship);
    }

    public Product GetProduct(GameManager.EProductName productName)
    {
        return _products[productName];
    }

    public Dictionary<GameManager.EProductName, Product> GetProducts()
    {
        return _products;
    }
}
