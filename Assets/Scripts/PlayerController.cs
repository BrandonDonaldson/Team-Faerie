using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    // Fields
    Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector2 currentPosition = transform.position;
        currentPosition += 5.0f* moveDirection * Time.deltaTime;
        transform.position = currentPosition;
    }

    public void move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();

        // Temporary solution to clamping cardinal directions
        if (moveDirection.x != 0)
        {
            moveDirection.y = 0;
        }
    }
}
