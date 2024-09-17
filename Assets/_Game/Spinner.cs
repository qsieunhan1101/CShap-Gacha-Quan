using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float speed = 0;
    [SerializeField] private float speedMax = 700;
    [SerializeField] string stopAt = "4";
    [SerializeField] bool stop = false;
    [SerializeField] bool spin = true;
    [SerializeField] private float slowDown = 7f;


    [SerializeField] float time = 0;


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
    // Update is called once per frame
    void FixedUpdate()
    {
        spinning();
    }

    void startSpinning()
    {
        stopAt = Random.Range(1,12).ToString();
        speed = speedMax;
        spin = true;
        stop = false;
        time = Random.Range(2, 4);

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
            UICanvas.instance.panel.SetActive(true);
            UICanvas.instance.text.text = $"Score: {stopAt}";
        }
    }
}
