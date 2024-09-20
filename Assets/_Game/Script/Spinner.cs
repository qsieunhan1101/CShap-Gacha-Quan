
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] string stopAt = "4";
    [SerializeField] bool stop = false;
    [SerializeField] bool spin = true;
    [SerializeField] private float slowDown = 7f;
    [SerializeField] private float speedMax = 700;
    [SerializeField] float speed = 0;

    [SerializeField] float time = 0;


    private void OnEnable()
    {
    }
    private void OnDisable()
    {

    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;

        }
        if (time <= 0)
        {
            stop = true;
        }
    }
    void FixedUpdate()
    {
        spinning();
    }
    /// <summary>
    /// khoi tao, reset cac gia tri khi bat dau quay
    /// </summary>
    void startSpinning()
    {
        stopAt = Random.Range(1,12).ToString();
        speed = speedMax;
        spin = true;
        stop = false;
        time = Random.Range(2, 4);

    }
    /// <summary>
    /// quay vong quay dua tren van toc
    /// </summary>
    void spinning()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);

        stopSpinning();
    }
    /// <summary>
    /// check dieu kien stop de giam dan toc do quay
    /// </summary>
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
