using System.Collections.Generic;
using UnityEngine;

public class MySpinner2 : MonoBehaviour
{
    [SerializeField] private float vMax;
    [SerializeField] private float vMin;
    [SerializeField] private float speed;
    [SerializeField] private float tRandom;
    [SerializeField] private float time;
    [SerializeField] private float t;

    [SerializeField] private float ran;

    [SerializeField] private bool isSlowDown = false;
    [SerializeField] private bool isStop = false;

    [SerializeField] private List<string> values;

    void Start()
    {
        speed = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClickSpin();
        }

        if (isStop == false)
        {
        spinning();

        }


       



    }

    private void startSpin()
    {
        speed = vMax;
        time = 0;
        t = 0;
        tRandom = Random.Range(4, 7);
        ran = Random.Range(1, 2.5f);
        isSlowDown = false;
        isStop = false;
    }

    private void spinning()
    {
        if (speed > 0)
        {
            time += Time.deltaTime;
        }
        if (time > ran && isSlowDown == false)
        {
            isSlowDown = true;
            time = 0;
        }
        slowDown();

        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
    private void slowDown()
    {
        if (isSlowDown == false)
        {
            return;
        }
        t = time / (tRandom - ran);
        float easing = easingOutQuint(t);
        speed = Mathf.Lerp(vMax, vMin, easing);
        if (speed>=0 && speed < 2)
        {
            speed = 0;
            isStop = true;
            UICanvas.instance.openUIClose(getValueOfSpin());
        }
    }

    private float easingOutQuint(float t)
    {
        return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
    }

    private void onClickSpin()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("SpinButton"))
            {
                startSpin();
            }
        }
    }

    private string getValueOfSpin()
    {
        float ang = 360f / 11;

        for (int i = 0; i < values.Count; i++)
        {
            if (transform.eulerAngles.z >= ang * i && transform.eulerAngles.z < ang * (i + 1))
            {
                return values[i];
            }
        }
        return "";
    }

}
