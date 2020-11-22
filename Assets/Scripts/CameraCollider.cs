using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private LineRenderer _line;

    private void OnEnable()
    {
        _canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_canvas.isActiveAndEnabled)
        {
            _canvas.gameObject.transform.rotation = Quaternion.LookRotation(_canvas.worldCamera.transform.forward);
            _line.SetPosition(0, _canvas.transform.position);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("MainCamera"))
        {
            _canvas.gameObject.SetActive(true);
            _canvas.worldCamera = collider.GetComponent<Camera>();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("MainCamera"))
        {
            _canvas.gameObject.SetActive(false);
        }
    }
}