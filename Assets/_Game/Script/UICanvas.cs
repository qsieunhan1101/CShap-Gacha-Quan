using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private Button btnSpin;
    [SerializeField] public GameObject panel;
    [SerializeField] public TextMeshProUGUI text;

    public static UICanvas instance;
    public static Action onSpin;

    void Start()
    {
        UICanvas.instance = this;
        btnSpin.onClick.AddListener(Spin);
    }
    /// <summary>
    /// goi ham Spinner.startSpinning() de bat dau quay
    /// </summary>
    void Spin()
    {
        onSpin!.Invoke();
        panel.SetActive(false);
    }
}
