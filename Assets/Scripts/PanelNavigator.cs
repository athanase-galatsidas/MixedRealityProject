using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelNavigator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;
    [SerializeField]
    private GameObject buttonPannel;
    private bool isVisible;

    public void GotoPanel(int index)
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        panels[index].SetActive(true);
    }

    public void CloseAll()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        buttonPannel.SetActive(false);
        isVisible = false;
    }

    private void OnMouseDown()
    {
        OpenMenu();
    }

    public void OpenMenu()
    {
        if (!isVisible)
        {
            isVisible = true;
            buttonPannel.SetActive(true);
            GotoPanel(0);
        }
    }
}