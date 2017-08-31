using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Text _shipNameLbl;

    private enum HUDState
    {
        None,
        Nothing,
        Ship
    }

    private bool _showRelationships;
    private HUDState _currentState;

    private void Update()
    {
        switch (_currentState)
        {
            case HUDState.Nothing:
                // Ocultar panel y mostrar panel diferente
                break;
            case HUDState.Ship:
                // Ocultar panel y mostrar panel diferente
                break;
            default:

                break;
        }

        if (_showRelationships)
        {
            //TODO: Activar ventana de relaciones
        }
    }

    private void HideAllPanels()
    {

    }

    public void UpdateShipName(string newName)
    {
        _shipNameLbl.text = newName;
    }
}