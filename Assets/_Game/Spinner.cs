using System;
using TMPro;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed = 700;
    [SerializeField] private float speedMax = 700;
    [SerializeField] string stopAt = "4";
    [SerializeField] bool stop = false;
    [SerializeField] bool spin = true;
    private float slowDown = 7f;




    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        UICanvas.onSpin += startSpinning;
    }
    private void OnDisable()
    {
        UICanvas.onSpin -= startSpinning;

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        spinning();
    }

    void startSpinning()
    {
        speed = speedMax;
        spin = true;
        stop = false;
    }

    void spinning()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);

        stopSpinning();
    }

    void stopSpinning()
    {
        if (!stop)
        {
            return;
        }
        if (stopAt == CheckElement.instance.textElement)
        {
            spin = false;
        }
        if (spin)
        {
            return;
        }
        speed -= slowDown;
        if (speed < 0)
        {
            speed = 0;
        }
    }
}
