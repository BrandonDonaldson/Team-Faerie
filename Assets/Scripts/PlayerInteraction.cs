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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        InterfaceRef.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool DetectInteractable()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1.0f, mask);

        if (hit)
        {
            return hit.collider.gameObject.tag != "Untagged";
        }
        else
        {
            return false;
        }
    }

    private GameObject ReturnInteractable()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1.0f, mask);

        if (hit)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started && DetectInteractable())
        {
            InterfaceRef.SetActive(true);
            InterfaceScript.targetObject = ReturnInteractable();
            PlyrCtrl.pSt = PlayerState.Interacting;
        }
    }
}