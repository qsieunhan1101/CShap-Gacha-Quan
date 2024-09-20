using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button btn;

    public static UICanvas instance;

    void Start()
    {
        UICanvas.instance = this;
        btn.onClick.AddListener(onClose);
    }

    void onClose()
    {
        panel.SetActive(false);
    }
    public void openUIClose(string text)
    {
        panel.SetActive(true);
        this.text.text = text;

    }
}
