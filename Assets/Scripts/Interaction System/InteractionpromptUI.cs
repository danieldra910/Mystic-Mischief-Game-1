using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionpromptUI : MonoBehaviour
{
    private Camera _mainCam;
   [SerializeField] public GameObject _uiPanel;
   [SerializeField] private TextMeshProUGUI _promptText;

   private void Start()
   {
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
   }

   private void LateUpdate()
   {
    var rotation = _mainCam.transform.rotation;
    transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
   }

    public bool IsDisplayed = false;

    public void Setup(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
