using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelNavigator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _panels;
    [SerializeField]
    private GameObject _buttonPannel, _priceTag;
    private bool _isVisible;

    public void GotoPanel(int index)
    {
        foreach (GameObject panel in _panels)
        {
            if (panel.activeSelf)
                StartCoroutine(DelayedDisable(panel));
            else
                panel.SetActive(false);
        }
        _panels[index].SetActive(true);
        _panels[index].GetComponent<Animator>().Play("AnimPanelSlideIn");
    }

    private IEnumerator DelayedDisable(GameObject panel)
    {
        panel.GetComponent<Animator>().Play("AnimPanelSlideOut");
        yield return new WaitForSeconds(.2f);
        panel.SetActive(false);
    }

    public void CloseAll()
    {
        foreach (GameObject panel in _panels)
        {
            panel.SetActive(false);
        }

        _buttonPannel.SetActive(false);
        _priceTag.SetActive(true);
        _isVisible = false;
    }

    private void OnMouseDown()
    {
        OpenMenu();
    }

    public void OpenMenu()
    {
        if (!_isVisible)
        {
            _isVisible = true;
            _buttonPannel.SetActive(true);
            _priceTag.SetActive(false);
            GotoPanel(0);
        }
    }
}