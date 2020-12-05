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
    private TextMeshProUGUI _tmpPrice, _tmpPriceValue, _tmpWeightValue;
    [SerializeField]
    private GameObject _fruitObject;
    private Renderer _fruitRenderer;

    private Vector3 _baseScale;

    [SerializeField]
    private float _basePrice, _baseWeight;

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
        float price = _basePrice * (.5f + _sliderFreshness.value) * (.5f + _sliderSize.value);
        _tmpPrice.text = $"€ {price.ToString("0.00")}";
        _tmpPriceValue.text = $"€ {price.ToString("0.00")}";
        _tmpWeightValue.text = $"{((.5f + _sliderSize.value) * _baseWeight).ToString("0.00")} kg";
    }
}