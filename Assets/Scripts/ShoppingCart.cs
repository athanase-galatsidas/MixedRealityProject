using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingCart : MonoBehaviour
{
    [SerializeField]
    private ShoppingCartItem _item;
    [SerializeField]
    private Animator _animPanel;
    [SerializeField]
    private GameObject _container;

    private bool _open;

    public void AddItem(string name, float price)
    {
        if (!_animPanel.gameObject.activeSelf)
            _animPanel.gameObject.SetActive(true);

        ShoppingCartItem shopItem = Instantiate(_item, _container.transform);
        shopItem.TmpName.text = name;
        shopItem.TmpPrice.text = $"€ {price.ToString("0.00")}";
    }

    public void ToggleOpen()
    {
        _open = !_open;
        _animPanel.SetBool("Open", _open);
    }
}