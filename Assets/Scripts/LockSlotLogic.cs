using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockSlotLogic : MonoBehaviour
{
    public void IncreaseNumber()
    {
        TextMeshProUGUI textElement = GetComponent<TextMeshProUGUI>();

        int currentNumber = int.Parse(textElement.text);

        currentNumber++;

        if (currentNumber > 9)
        {
            currentNumber = 0;
        }

        textElement.text = "" + currentNumber;
    }

    public void DecreaseNumber()
    {
        TextMeshProUGUI textElement = GetComponent<TextMeshProUGUI>();

        int currentNumber = int.Parse(textElement.text);

        currentNumber--;

        if (currentNumber < 0)
        {
            currentNumber = 9;
        }

        textElement.text = "" + currentNumber;
    }
}
