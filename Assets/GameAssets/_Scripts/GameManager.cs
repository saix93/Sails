using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private HUD _hud;
    
    private static float _shipMovementThreshold = 0.01f;

    [SerializeField]
    private int gold;

    public enum EFactionName
    {
        None,
        Player,
        Pirate,
        Blue,
        Red,
        Green
    }

    public enum EFactionRelation
    {
        None,
        Hostile,
        Unpopular,
        Neutral,
        Friendly
    }

    public enum EProductName
    {
        None,
        Grain,
        Fruit,
        Meat,
        Beer,
        Wine,
        Fish,
        Wood,
        Brick,
        Sugar,
        Rope
    }

    public static Faction PlayerFaction
    {
        get; private set;
    }

    public static Ship SelectedPlayerShip
    {
        get; private set;
    }

    public static int Gold
    {
        get; set;
    }

    public static float ShipMovementThreshold
    {
        get
        {
            return _shipMovementThreshold;
        }
        private set
        {
            _shipMovementThreshold = value;
        }
    }

    private List<Town> _towns = new List<Town>();

    private static Dictionary<EFactionName, Faction> _factions = new Dictionary<EFactionName, Faction>();
    private static Dictionary<EProductName, Product> _basicProducts = new Dictionary<EProductName, Product>();

    /* Metodos */

    private void InitializeGame()
    {
        foreach (EFactionName f in System.Enum.GetValues(typeof(EFactionName)))
        {
            _factions[f] = new Faction(f, Color.clear, new Relationships(EFactionRelation.Neutral));
        }

        foreach (EProductName p in System.Enum.GetValues(typeof(EProductName)))
        {
            _basicProducts[p] = new Product(p, 120, 80, 40);
        }

        // Se selecciona la facción del player
        PlayerFaction = _factions[EFactionName.Player];

        // Se actualizan los colores de las facciones
        _factions[EFactionName.Player].Color = Color.magenta;
        _factions[EFactionName.Pirate].Color = Color.black;
        _factions[EFactionName.Blue].Color = Color.blue;
        _factions[EFactionName.Red].Color = Color.red;
        _factions[EFactionName.Green].Color = Color.green;

        // Se actualizan las relaciones de las facciones
        _factions[EFactionName.Pirate].FactionRelationships = new Relationships(EFactionRelation.Hostile);
    }

    private void Awake()
    {
        InitializeGame();
    }

    private void Update()
    {
        Gold = gold;

        if (Input.GetButtonDown("LeftClick"))
        {
            int layerMask = 1 << LayerMask.NameToLayer("Ships") | 1 << LayerMask.NameToLayer("Towns");

            Collider2D[] colArray = Physics2D.OverlapPointAll(GetMousePosition(), layerMask);

            if (colArray.Length == 0)
            {
                SelectedPlayerShip = null;
                //TODO: Limpiar parte de abajo del HUD
                return;
            }

            foreach (Collider2D col in colArray)
            {
                if (col.gameObject.layer == LayerMask.NameToLayer("Ships"))
                {
                    // Si se hace click en un barco

                    Ship ship = col.GetComponent<Ship>();

                    _hud.UpdateShipName(ship.ShipName);

                    if (ship.Faction == PlayerFaction)
                    {
                        SelectedPlayerShip = ship;

                        // Se rompe el bucle en caso de que se haya seleccionado un barco del jugador para darle prioridad
                        break;
                    }
                    else
                    {
                        SelectedPlayerShip = null;
                    }
                }
                else if (col.gameObject.layer == LayerMask.NameToLayer("Towns"))
                {
                    // Si se hace click en una ciudad
                }
            }
        }
    }

    public static Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static Faction GetFaction(EFactionName faction)
    {
        return _factions[faction];
    }

    public static Dictionary<EProductName, Product> GetBasicProducts()
    {
        return _basicProducts;
    }
}
