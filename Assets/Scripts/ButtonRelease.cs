using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UIElements;

enum ButtonType
{
    Slash,
    Fire,
    Wind,
    Light,
    Info,
    Talk,
    Action,
    Run
}

public class ButtonRelease : MonoBehaviour
{
    [SerializeField] ButtonType buttonType;
    [SerializeField] UIEvent interfaceRef;

    public void Activate()
    {
            Debug.Log("Button selected: " + gameObject.name);

            // Put your button functionality here
    }
}
