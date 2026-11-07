using UnityEngine;
using UnityEngine.InputSystem;

public class ShowRadialMenu : MonoBehaviour
{
    [SerializeField] GameObject radialMenu;

    private Vector3 mousePos;
    private InputActionPhase mouseAction = InputActionPhase.Disabled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePos = Mouse.current.position.ReadValue();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mouseAction);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        mousePos = Mouse.current.position.ReadValue();
        mouseAction = context.phase;
    }
}
