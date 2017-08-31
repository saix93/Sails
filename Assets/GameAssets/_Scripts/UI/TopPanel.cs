using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopPanel : MonoBehaviour
{
    [SerializeField]
    private Text _goldLbl;

    private void OnGUI()
    {
        UpdateGold();
    }

    private void UpdateGold()
    {
        _goldLbl.text = GameManager.Gold.ToString("n0", System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"));
    }
}
