using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCanvas : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Text _shipNameLbl;
    [SerializeField]
    private Image _shipNameImage;

    private Ship _ship;

    private void Awake()
    {
        _ship = this.GetComponentInParent<Ship>();
    }

    private void Start()
    {
        _shipNameLbl.text = _ship.ShipName;
    }

    public void UpdateShipFaction(Faction faction)
    {
        _shipNameImage.color = faction.Color;
    }
}
