using UnityEngine;

public class MySpinner : MonoBehaviour
{

    [SerializeField] private float s;
    [SerializeField] private float t;
    [SerializeField] private float v;
    [SerializeField] private float a;

    [SerializeField] private float speed;

    public bool stop = false;


    [SerializeField] string value = "1";

    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.Rotate(0, 0, speed * Time.deltaTime);

        speed = v + a * time;
        if (speed <= 0)
        {
            speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            checkValue();
            Debug.Log("ddddddddddđ");
        }
        checkValue();
    }


    void checkValue()
    {
        if (value == CheckElement.instance.textElement)
        {
            s = 360 * 3;
            a = (2 * (s - v * t)) / (t * t);
            
        }

    }
    void stopSpin()
    {

    }
}
