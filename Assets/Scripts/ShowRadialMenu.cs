using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShowRadialMenu : MonoBehaviour
{
    [SerializeField] private GameObject holdMenu;

    private PointerEventData pointerData;
    private List<RaycastResult> results = new List<RaycastResult>();

    void Start()
    {
        holdMenu.SetActive(false);
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        // Left mouse button pressed
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            holdMenu.SetActive(true);

            // Move the menu to the mouse position
            holdMenu.transform.position = Input.mousePosition;
        }

        // Left mouse button released
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            CheckHoveredButton();
            holdMenu.SetActive(false);
        }
    }

    void CheckHoveredButton()
    {
        // Get the current Event System
        EventSystem eventSystem = EventSystem.current;

        if (eventSystem == null)
            return;

        // Set up pointer data
        pointerData = new PointerEventData(eventSystem);
        pointerData.position = Mouse.current.position.ReadValue();
         
        // Perform UI raycast
        results.Clear();
        eventSystem.RaycastAll(pointerData, results);

        // Check everything underneath the cursor
        foreach (RaycastResult result in results)
        {
            ButtonRelease button = result.gameObject.GetComponentInParent<ButtonRelease>();
            if (button != null)
            {
                button.Activate();
                return;
            }
        }
    }
}
