﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitController : MonoBehaviour
{
    [SerializeField]
    private Color _colorFresh, _colorExpired;
    [SerializeField]
    private Slider _sliderFreshness, _sliderSize;
    [SerializeField]
    private GameObject _fruitObject;
    private Renderer _fruitRenderer;

    private Vector3 _baseScale;

    private void Awake()
    {
        _fruitRenderer = _fruitObject.GetComponent<Renderer>();
        _baseScale = _fruitObject.transform.localScale;

        _sliderFreshness.value = .5f;
        _sliderSize.value = .5f;

        _sliderFreshness.onValueChanged.AddListener(delegate { ChangeColor(); });
        _sliderSize.onValueChanged.AddListener(delegate { ChangeSize(); });
    }

    public void ChangeColor()
    {
        if (_sliderFreshness.value < .5f)
        {
            _fruitRenderer.material.SetColor("_Color", Color.Lerp(_colorFresh, Color.white, _sliderFreshness.value * 2));
        }
        else
        {
            _fruitRenderer.material.SetColor("_Color", Color.Lerp(Color.white, _colorExpired, (_sliderFreshness.value * 2) - 1));
        }
    }

    public void ChangeSize()
    {
        _fruitObject.transform.localScale = _baseScale * (.5f + _sliderSize.value);
    }
}