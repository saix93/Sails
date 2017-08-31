using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product
{
    public GameManager.EProductName ProductName
    {
        get; private set;
    }

    public int BuyPrice
    {
        get; set;
    }

    public int SellPrice
    {
        get; set;
    }

    public int Amount
    {
        get; set;
    }

    public Product(GameManager.EProductName newName, int newBuyPrice, int newSellPrice, int newAmount)
    {
        ProductName = newName;
        BuyPrice = newBuyPrice;
        SellPrice = newSellPrice;
        Amount = newAmount;
    }
}
