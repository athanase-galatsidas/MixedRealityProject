using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
    [SerializeField]
    private ShoppingCartItem _item;

    public void AddItem(string name, float price)
    {
        ShoppingCartItem shopItem = Instantiate(_item, transform);
        shopItem.TmpName.text = name;
        shopItem.TmpPrice.text = $"€ {price.ToString("0.00")}";
    }
}