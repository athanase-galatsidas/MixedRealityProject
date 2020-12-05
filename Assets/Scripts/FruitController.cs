using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FruitController : MonoBehaviour
{
    [SerializeField]
    private Color _colorFresh, _colorExpired;
    [SerializeField]
    private Slider _sliderFreshness, _sliderSize;
    [SerializeField]
    private TextMeshProUGUI _tmpWeightValue;
    [SerializeField]
    private TextMeshProUGUI[] _tmpPriceTags;
    [SerializeField]
    private GameObject _fruitObject, _btnAddList;
    private Renderer _fruitRenderer;

    private Vector3 _baseScale;
    private float _priceCalculated;

    [SerializeField]
    private float _basePrice, _baseWeight;
    [SerializeField]
    private string _objName;

    private void Awake()
    {
        _fruitRenderer = _fruitObject.GetComponent<Renderer>();
        _baseScale = _fruitObject.transform.localScale;

        _sliderFreshness.value = .5f;
        _sliderSize.value = .5f;

        _sliderFreshness.onValueChanged.AddListener(delegate { ChangeColor(); });
        _sliderSize.onValueChanged.AddListener(delegate { ChangeSize(); });

        UpdateValues();
    }

    public void ChangeColor()
    {
        if (_sliderFreshness.value < .5f)
        {
            _fruitRenderer.material.SetColor("_Color", Color.Lerp(_colorExpired, Color.white, _sliderFreshness.value * 2));
        }
        else
        {
            _fruitRenderer.material.SetColor("_Color", Color.Lerp(Color.white, _colorFresh, (_sliderFreshness.value * 2) - 1));
        }
    }

    public void ChangeSize()
    {
        _fruitObject.transform.localScale = _baseScale * (.5f + _sliderSize.value);
    }

    public void UpdateValues()
    {
        _priceCalculated = _basePrice * (.5f + _sliderFreshness.value) * (.5f + _sliderSize.value);

        foreach (TextMeshProUGUI tmp in _tmpPriceTags)
        {
            tmp.text = $"€ {_priceCalculated.ToString("0.00")}";
        }

        _tmpWeightValue.text = $"{((.5f + _sliderSize.value) * _baseWeight).ToString("0.00")} kg";
    }

    public void AddToList()
    {
        _btnAddList.SetActive(false);
        FindObjectOfType<ShoppingCart>().AddItem(_objName, _priceCalculated);
    }
}