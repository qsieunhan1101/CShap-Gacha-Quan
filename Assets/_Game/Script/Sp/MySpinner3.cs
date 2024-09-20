using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MySpinner3 : MonoBehaviour
{
    [SerializeField] private float vMax;
    [SerializeField] private float vMin;
    [SerializeField] private float speed;
    [SerializeField] private float time;
    [SerializeField] private float tRandom;
    [SerializeField] private float t;

    [SerializeField] private bool isSlowDown = false;
    [SerializeField] private bool isStop = false;
    [SerializeField] private float ran;
    [SerializeField] private bool isLastSpin = false;

    [SerializeField] private List<string> values;
    [SerializeField] private int randomValues = 0;
    [SerializeField] private float currentAngle;
    [SerializeField] private float deltaAngle;


    [SerializeField] private float elapsedTime = 0f;
    public float duration = 5f;
    private float targetAngle;
    private float startAngle;


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
        if (isLastSpin == true && isStop ==false)
        {
            checkValuesOfSpin();
        }
    }

    private void startSpin()
    {
        speed = vMax;
        time = 0;
        t = 0;
        tRandom = Random.Range(4, 7);
        ran = Random.Range(1, 2.5f);
        randomValues = Random.Range(0, values.Count);
        isSlowDown = false;
        isLastSpin = false;
        isStop = false;


        targetAngle = randomValues * (360 / 11) + 360f + 15f;
    }

    private void spinning()
    {
        if (speed > 0 && isLastSpin == false)
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
        t =  Mathf.Clamp01(time / (tRandom - ran)) ;
        
        speed = Mathf.Lerp(vMax, vMin, t);
        if (speed > vMin+1 && speed < vMin+10 && isLastSpin == false)
        {
            speed = vMin;
            isLastSpin = true;
            currentAngle = transform.eulerAngles.z;
            Debug.Log("sssssssssssssss");

            startAngle = transform.eulerAngles.z;
            elapsedTime = 0;
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
    private void checkValuesOfSpin()
    {
        float valueAngleStart = randomValues * (360f / 11);
        float valueAngleEnd = (randomValues + 1) * (360f / 11);

        float eulerAngle = transform.eulerAngles.z;

        /*        if (eulerAngle >= valueAngleStart + 15 && eulerAngle < valueAngleEnd)
                {
                    speed = 0;
                    isStop = true;
                    UICanvas.instance.openUIClose(getValueOfSpin());
                }*/

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        float currentAngle = Mathf.Lerp(startAngle, targetAngle, elapsedTime / duration);
        transform.eulerAngles = new Vector3(0, 0, currentAngle);



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
