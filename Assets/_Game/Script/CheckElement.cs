using UnityEngine;

public class CheckElement : MonoBehaviour
{
    public static CheckElement instance;

    public string textElement;

    public const string TAG_ELEMENT = "Element";
    void Start()
    {
        CheckElement.instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_ELEMENT))
        {
            textElement = other.transform.GetComponent<Element>().textElement.text;
        }
    }
}
