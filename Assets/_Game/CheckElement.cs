using TMPro;
using UnityEngine;

public class CheckElement : MonoBehaviour
{


    public static CheckElement instance;

    public string textElement;
    // Start is called before the first frame update
    void Start()
    {
        CheckElement.instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Element"))
        {
            Debug.Log(other.transform.name);
            textElement = other.transform.GetComponent<Element>().textElement.text;
        }
    }
}
