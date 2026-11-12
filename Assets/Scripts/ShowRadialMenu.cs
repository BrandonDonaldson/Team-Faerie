using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShowRadialMenu : MonoBehaviour
{
    [SerializeField] private GameObject holdMenu;
    [SerializeField] public PlayerController playerController;
    [SerializeField] PlayerInteraction playerInteractionControls;
    [SerializeField] UIEvent interfaceUI;

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

        // Left mouse button pressed and if the player can interact with what they're facing
        if (Mouse.current.leftButton.wasPressedThisFrame && playerInteractionControls.DetectInteractable())
        {
            // Make sure that there is an interactible in front of the player
            // Switch player mode to interacting
            playerController.PSt = PlayerState.Interacting;

            holdMenu.SetActive(true);

            // Move the menu to the mouse position
            holdMenu.transform.position = Input.mousePosition;

            interfaceUI.SetMenu();
        }

        // Left mouse button released
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            CheckHoveredButton();
            holdMenu.SetActive(false);
            // Set player mode to moving
            playerController.PSt = PlayerState.Moving;
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
            if (button != null && button.gameObject.GetComponentInParent<Button>().IsInteractable())
            {
                button.Activate();
                return;
            }
        }
    }
}
