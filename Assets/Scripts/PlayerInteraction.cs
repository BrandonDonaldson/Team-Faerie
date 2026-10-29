using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // References
    [SerializeField] PlayerController PlyrCtrl;
    [SerializeField] PlayerMovement PlyrMovement;
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
        RaycastHit2D hit = DetectHit();

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
        RaycastHit2D hit = DetectHit();
        if (hit)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    private RaycastHit2D DetectHit()
    {
        // Obtain player direction
        Vector3 playerDirection = new Vector3();
        switch(PlyrMovement.PlayerDirection)
        {
            case PlayerDirection.Left:
                playerDirection = transform.right * -1;
                break;
            case PlayerDirection.Right:
                playerDirection = transform.right;
                break;
            case PlayerDirection.Down:
                playerDirection = transform.up * -1;
                break;
            case PlayerDirection.Up:
                playerDirection = transform.up;
                break;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, 1.0f, mask);
        return hit;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (PlyrCtrl.pSt != PlayerState.Paused && context.started && DetectInteractable())
        {
            InterfaceRef.SetActive(true);
            InterfaceScript.targetObject = ReturnInteractable();
            InterfaceScript.CallForResult();
            PlyrCtrl.pSt = PlayerState.Interacting;
        }
    }
}