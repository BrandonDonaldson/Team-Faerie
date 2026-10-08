using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player Movement class, handles movement and animation calls
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed = 4f;
    [SerializeField] LayerMask collisionMask;
    [SerializeField] PlayerController playerController;

    public Transform movePoint;
    private Vector2 inputDirection;
    private Vector2 previousInputDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movePoint.parent = null;
        previousInputDirection = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player to the move point
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, playerMoveSpeed * Time.deltaTime);

        // Determine player movement direction
        if(playerController.pSt == PlayerState.Moving)
        {
            // Check to see if player is on the move point before allowing the player to move further
            if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                // Check if multiple keys are being pressed
                if (Mathf.Abs(inputDirection.x) == 1f && Mathf.Abs(inputDirection.y) == 1f)
                {
                    // Limit movement to newest keypress based on previous InputDirection
                    if (Mathf.Abs(previousInputDirection.y) == 1f)
                    {
                        inputDirection = new Vector2(inputDirection.x, 0f);
                    }
                    else if (Mathf.Abs(previousInputDirection.x) == 1f)
                    {
                        inputDirection = new Vector2(0f, inputDirection.y);
                    }
                }

                // If the keypress is in the horizontal direction
                if (Mathf.Abs(inputDirection.x) == 1f)
                {
                    // Check for collision in the horizontal direction
                    if(!DetectCollison(true))
                    {
                        // Move the move point horizontally to the next grid square
                        movePoint.position += new Vector3(inputDirection.x, 0f, 0f);

                        // Set the previous Input Direction
                        previousInputDirection = new Vector2(inputDirection.x, 0f);
                    }
                }
                // If the keypress is in the vertial direction
                else if(Mathf.Abs(inputDirection.y) == 1f)
                {
                    // Check for collision in the vertical direction
                    if (!DetectCollison(false))
                    {
                        // Move the move point vertically to the next grid square
                        movePoint.position += new Vector3(0f, inputDirection.y, 0f);

                        // Set the previous Input Direction
                        previousInputDirection = new Vector2(0f, inputDirection.y);
                    }
                }
            }
        }
    }

    #region helper methods
    /// <summary>
    /// Detects if a collider object is in the direction of intended movement
    /// </summary>
    /// <param name="isHorizontal">True: check collision in the x direction,
    ///                            False: check collision in the y direction</param>
    /// <returns>True if collision is detected</returns>
    private bool DetectCollison(bool isHorizontal)
    {
        if(isHorizontal)
        {
            return Physics2D.Raycast(transform.position, new Vector2(inputDirection.x, 0f), 1f, collisionMask);
        }
        else
        {
            return Physics2D.Raycast(transform.position, new Vector2(0f, inputDirection.y), 1f, collisionMask);
        }
    }


    #endregion

    public void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }
}
