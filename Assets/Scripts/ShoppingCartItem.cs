using UnityEngine;
using TMPro;

public class ShoppingCartItem : MonoBehaviour
{
    public TextMeshProUGUI TmpName, TmpPrice;

    public void RemoveItem()
    {
        Destroy(gameObject);
    }
}