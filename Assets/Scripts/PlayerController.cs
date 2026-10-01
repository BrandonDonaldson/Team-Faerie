using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public enum PlayerState
{
    Moving,
    Interacting,
    Paused
}

public class PlayerController : MonoBehaviour
{
    // References
    [SerializeField] PlayerInteraction interactRef;
    [SerializeField] BoxCollider2D collider;
    [SerializeField] LayerMask mask;
    [SerializeField] public int HP; // Player Hit Points
    [SerializeField] public int MP; // Player Magic Points
    [SerializeField] public int DMG;
    [SerializeField] public int DMGVar;

    // Fields
    public string direction; // Direction
    Vector2 currentPosition; // Current Position (to be moved into)
    bool idle; // Is the player idle?
    public PlayerState pSt; // Player state (for the state machine)

    // Keeps track of the key being held
    bool movingUp;
    bool movingDown;
    bool movingLeft;
    bool movingRight;

    // Timers
    float moveTimer;
    [SerializeField] float moveDelay = 0.25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = "up";
        currentPosition = transform.position;
        moveTimer = moveDelay;
        pSt = PlayerState.Moving;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is idle (user is not pressing any keys)
        if (!movingUp && !movingDown && !movingLeft && !movingRight)
        {
            idle = true;
        }
        else
        {
            idle = false;
        }

        if(pSt == PlayerState.Moving)
        {
            // Movement
            CheckRotation(direction);

            // Count Down movement timer
            moveTimer -= Time.deltaTime;

            // Move repeatedly while a key is held
            if (moveTimer <= 0f)
            {
                if (movingUp)
                {
                    MovePlayer(new Vector2(0.0f, 1.0f));
                }
                else if (movingDown)
                {
                    MovePlayer(new Vector2(0.0f, -1.0f));
                }
                else if (movingLeft)
                {
                    MovePlayer(new Vector2(-1.0f, 0.0f));
                }
                else if (movingRight)
                {
                    MovePlayer(new Vector2(1.0f, 0.0f));
                }

                moveTimer = moveDelay;
            }
            // Move the player
            transform.position = currentPosition;
        }
    }

    /// <summary>
    /// Rotates player based on direction
    /// </summary>
    /// <param name="d">Direction</param>
    void CheckRotation(string d)
    {
        switch (d)
        {
            case "up":
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;

            case "down":
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                break;

            case "left":
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;

            case "right":
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                break;
        }

        // When the user isnt pressing any keys, keep idle running
        if (idle)
        {
            moveTimer = moveDelay;
        }
    }

    private bool DetectObstacle(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1.0f, mask);

        return !hit.collider;
    }

    /// <summary>
    /// Moves Player in the given direction
    /// </summary>
    /// <param name="moveDirection">Direction to move</param>
    /// <param name="newDirection">Direction the player will Face</param>
    public void MovePlayer(Vector2 moveDirection)
    {
        if(DetectObstacle(moveDirection))
        {
            currentPosition = (Vector2)transform.position + moveDirection;
        }
    }

    /// <summary>
    /// Stops the player from moving
    /// </summary>
    public void StopMovement()
    {
        movingUp = false;
        movingDown = false;
        movingLeft = false;
        movingRight = false;
    }

    #region Movement Callbacks
    // Movement Callbacks
    public void MoveUp(InputAction.CallbackContext context)
    {
        if (pSt == PlayerState.Moving)
        {
            if (context.started)
            {
                movingUp = true;
                movingDown = false;
                movingLeft = false;
                movingRight = false;

                direction = "up";
            }

            if (context.canceled)
            {
                movingUp = false;
            }
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (pSt == PlayerState.Moving)
        {
            if (context.started)
            {
                movingUp = false;
                movingDown = true;
                movingLeft = false;
                movingRight = false;

                direction = "down";
            }

            if (context.canceled)
            {
                movingDown = false;
            }
        }
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (pSt == PlayerState.Moving)
        {
            if (context.started)
            {
                movingUp = false;
                movingDown = false;
                movingLeft = true;
                movingRight = false;

                direction = "left";
            }

            if (context.canceled)
            {
                movingLeft = false;
            }
        }
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (pSt == PlayerState.Moving)
        {
            if (context.started)
            {
                movingUp = false;
                movingDown = false;
                movingLeft = false;
                movingRight = true;

                direction = "right";
            }

            if (context.canceled)
            {
                movingRight = false;
            }
        }
    }
    #endregion
}
