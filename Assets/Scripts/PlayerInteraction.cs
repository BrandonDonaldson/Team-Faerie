using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // References
    [SerializeField] PlayerController PlyrCtrl;
    [SerializeField] GameObject InterfaceRef;
    [SerializeField] UIEvent InterfaceScript;
    [SerializeField] LayerMask mask;

    // Fields
    Vector2 orient;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        InterfaceRef.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        switch (PlyrCtrl.direction)
        {
            case "up":
                orient = new Vector2(0f, 1.0f);
                break;

            case "down":
                orient = new Vector2(0f, -1.0f);
                break;

            case "left":
                orient = new Vector2(-1.0f, 0f);
                break;

            case "right":
                orient = new Vector2(-1.0f, 0f);
                break;
        }
    }

    private bool DetectInteractable()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, orient, 1.0f, mask);

        return hit.collider.gameObject.tag != "Untagged";
    }

    private Interactable ReturnInteractable()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, orient, 1.0f, mask);

        return hit.collider.gameObject.GetComponent<Interactable>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started && DetectInteractable())
        {
            InterfaceRef.SetActive(true);
            InterfaceScript.targetObject = ReturnInteractable();
        }
    }
}