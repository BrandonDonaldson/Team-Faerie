using UnityEngine;
using UnityEngine.UI;

public class ButtonColiderShrink : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
