using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    public static UICanvas instance;
    [SerializeField] private Button btnSpin;
    [SerializeField] public GameObject panel;
    [SerializeField] public TextMeshProUGUI text;

    public static Action onSpin;

    // Start is called before the first frame update
    void Start()
    {
        UICanvas.instance = this;
        btnSpin.onClick.AddListener(Spin);
    }


    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spin()
    {
        onSpin!.Invoke();
        panel.SetActive(false);
    }
}
