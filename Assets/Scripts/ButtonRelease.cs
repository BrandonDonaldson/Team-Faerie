using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UIElements;


public class ButtonRelease : MonoBehaviour
{
    [SerializeField] MenuState buttonCategory;
    [SerializeField] int buttonChoice;
    [SerializeField] UIEvent interfaceRef;

    public void Activate()
    {
        Debug.Log("Button selected: " + gameObject.name);
        interfaceRef.category = buttonCategory;
        interfaceRef.choice = buttonChoice;
        interfaceRef.CallForResult();
    }
}
