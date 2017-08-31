using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Commerce : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Text _townName;
    [SerializeField]
    private GameObject _productPrefab;
    [SerializeField]
    private Transform _productParent;

    private static bool _isShowing;
    private static Town _town;
    private static Ship _ship;

    /* Metodos */

    public static void ShowCommerce(Town town, Ship ship)
    {
        if (_isShowing) return;

        _town = town;
        _ship = ship;
        _isShowing = true;

        SceneManager.LoadScene("Commerce", LoadSceneMode.Additive);
    }

    private void Start()
    {
        FillProductTable();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    private void Close()
    {
        _isShowing = false;

        StartCoroutine(Close_Coroutine());
    }

    private IEnumerator Close_Coroutine()
    {
        yield return SceneManager.UnloadSceneAsync("Commerce");
    }

    private void FillProductTable()
    {
        _townName.text = _town.TownName;

        Dictionary<GameManager.EProductName, Product> products = _town.GetProducts();
        for (int i = 0; i < products.Count; i++)
        {
            GameObject go = Instantiate(_productPrefab, _productParent);

            Product product = products[(GameManager.EProductName)i];

            go.transform.Find("Text").GetComponent<Text>().text = product.ProductName.ToString();
            go.transform.Find("BuySellPanel/SellText").GetComponent<Text>().text = product.Amount.ToString();
            go.transform.Find("BuySellPanel/SellButton").GetComponentInChildren<Text>().text = product.SellPrice.ToString();
            go.transform.Find("BuySellPanel/BuyButton").GetComponentInChildren<Text>().text = product.BuyPrice.ToString();
        }
    }
}
