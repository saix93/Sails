using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownCanvas : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Text _townNameLbl;
    [SerializeField]
    private Text _numberOfShipsLbl;
    [SerializeField]
    private Image _townNameImage;

    private Town _town;

    private void Awake()
    {
        _town = this.GetComponentInParent<Town>();
    }

    private void Start()
    {
        _townNameLbl.text = _town.TownName;
    }

    public void UpdateShipNumber(int numberOfShips)
    {
        _numberOfShipsLbl.text = numberOfShips.ToString();
    }

    public void UpdateTownFaction(Faction faction)
    {
        _townNameImage.color = faction.Color;
    }
}
