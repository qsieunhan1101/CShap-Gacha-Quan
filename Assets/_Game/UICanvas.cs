using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private Button btnSpin;

    public static Action onSpin;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
