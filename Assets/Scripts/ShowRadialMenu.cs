using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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

    [SerializeField] private AudioClip openMenuClip;

    void Start()
    {
        holdMenu.SetActive(false);
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        // Left mouse button pressed and if the player can interact with what they're facing and not in pause menu
        if (Mouse.current.leftButton.wasPressedThisFrame && playerInteractionControls.DetectInteractable() && playerController.PSt != PlayerState.Paused && !interfaceUI.lockUI.active)
        {
            // Make sure that there is an interactible in front of the player
            // Switch player mode to interacting
            playerController.PSt = PlayerState.Interacting;

            holdMenu.SetActive(true);

            // Play the sound effect whenever the menu opens
            if (openMenuClip != null && SFXManager.Instance != null)
            {
                SFXManager.Instance.PlaySFX(openMenuClip);
            }

            // Move the menu to the mouse position
            holdMenu.transform.position = Input.mousePosition;

            // Check if menu is off screen 
            Debug.Log(Screen.width);
            Debug.Log(Input.mousePosition.x);

            if (Input.mousePosition.x > (Screen.width - (Screen.width * 0.2)))
            {
                holdMenu.transform.position = new Vector2((float)(Screen.width - (Screen.width * 0.2)), holdMenu.transform.position.y);
            }
            else if (Input.mousePosition.x < (Screen.width * 0.2))
            {
                holdMenu.transform.position = new Vector2((float)(Screen.width * 0.2), holdMenu.transform.position.y);
            }

            if (Input.mousePosition.y > (Screen.height - (Screen.height * 0.35)))
            {
                holdMenu.transform.position = new Vector2(holdMenu.transform.position.x, (float)(Screen.height - (Screen.height * 0.35)));
            }
            else if (Input.mousePosition.y < (Screen.height * 0.35))
            {
                holdMenu.transform.position = new Vector2(holdMenu.transform.position.x, (float)(Screen.height * 0.35));
            }

            interfaceUI.SetMenu();
        }

        // Left mouse button released and not in pause menu
        if (Mouse.current.leftButton.wasReleasedThisFrame && playerController.PSt != PlayerState.Paused && !interfaceUI.lockUI.active)
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
