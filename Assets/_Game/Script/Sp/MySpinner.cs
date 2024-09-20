
using System.Collections.Generic;
using UnityEngine;

public class MySpinner : MonoBehaviour
{

    [SerializeField] private float speed;

    [SerializeField] private float time;
    [SerializeField] private bool isSlowDown = false;
    [SerializeField] private float slownDown = 0;
    [SerializeField] private float t = 0;

    [SerializeField] private List<string> lis = new List<string>();



    // Start is called before the first frame update
    void Start()
    {
        //time = Random.RandomRange(2,4);
    }

    // Update is called once per frame
    void Update()
    {


        slownDownRandom();
        t = t + Time.deltaTime;
        if (t >= time)
        {
            isSlowDown = true;
        }

    }

    private void slownDownRandom()
    {
        stopSpin();
        transform.Rotate(0, 0, speed * Time.deltaTime);

    }

    private void stopSpin()
    {

        if (isSlowDown == true)
        {
            speed = speed - slownDown;
            if (speed == 100)
            {
                slownDown = 0.1f;
            }

            if (speed <= 0)
            {
                speed = 0;
                slownDown = 0;
                //getValue();
                TestFors();
            }
        }
    }

    private void TestFors()
    {
        float ang = 360 / 11;
        
        for (int i = 0; i < lis.Count; i++)
        {
            if (transform.eulerAngles.z >= ang*i && transform.eulerAngles.z < ang*(i+1))
            {
                Debug.Log(lis[i]);
            }
        }
    }

    private void getValue()
    {
        float ang = 360 / 11f;

        if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < ang)
        {
            Debug.Log("5K");
        }
        if (transform.eulerAngles.z >= ang && transform.eulerAngles.z < ang * 2)
        {
            Debug.Log("10K");

        }
        if (transform.eulerAngles.z >= ang * 2 && transform.eulerAngles.z < ang * 3)
        {
            Debug.Log("20K");

        }
        if (transform.eulerAngles.z >= ang * 3 && transform.eulerAngles.z < ang * 4)
        {
            Debug.Log("Quay lai");

        }
        if (transform.eulerAngles.z >= ang * 4 && transform.eulerAngles.z < ang * 5)
        {
            Debug.Log("50K");

        }
        if (transform.eulerAngles.z >= ang * 5 && transform.eulerAngles.z < ang * 6)
        {
            Debug.Log("30K");

        }
        if (transform.eulerAngles.z >= ang * 6 && transform.eulerAngles.z < ang * 7)
        {
            Debug.Log("100K");

        }
        if (transform.eulerAngles.z >= ang * 7 && transform.eulerAngles.z < ang * 8)
        {
            Debug.Log("Nhan doi");

        }
        if (transform.eulerAngles.z >= ang * 8 && transform.eulerAngles.z < ang * 9)
        {
            Debug.Log("200K");

        }
        if (transform.eulerAngles.z >= ang * 9 && transform.eulerAngles.z < ang * 10)
        {
            Debug.Log("Chia doi");

        }
        if (transform.eulerAngles.z >= ang * 10 && transform.eulerAngles.z < ang * 11)
        {
            Debug.Log("500K");

        }


    }
}