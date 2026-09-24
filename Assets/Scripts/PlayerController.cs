using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

enum PlayerState
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

    // Fields
    int HP; // Player Hit Points
    int MP; // Player Magic Points
    string direction; // Direction
    Vector2 currentPosition; // Current Position (to be moved into)
    bool idle; // Is the player idle?
    PlayerState pSt; // Player state (for the state machine)

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
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        transform.position = currentPosition;
        CheckRotation(direction);

        // Count Down movement timer
        moveTimer -= Time.deltaTime;

        // Move repeatedly while a key is held
        if (moveTimer <= 0f)
        {
            if (movingUp)
            {
                MovePlayer(new Vector2(0.0f, 1.0f), "up");
            }
            else if (movingDown)
            {
                MovePlayer(new Vector2(0.0f, -1.0f), "down");
            }
            else if (movingLeft)
            {
                MovePlayer(new Vector2(-1.0f, 0.0f), "left");
            }
            else if (movingRight)
            {
                MovePlayer(new Vector2(1.0f, 0.0f), "right");
            }

            moveTimer = moveDelay;
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
    public void MovePlayer(Vector2 moveDirection, string newDirection)
    {
        direction = newDirection;

        if(DetectObstacle(moveDirection))
        {
            currentPosition = (Vector2)transform.position + moveDirection;
        }
    }

    // Movement Callbacks
    public void MoveUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            movingUp = true;
            movingDown = false;
            movingLeft = false;
            movingRight = false;

            direction = "up";
            moveTimer = 0f;
        }

        if (context.canceled)
        {
            movingUp = false;
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            movingUp = false;
            movingDown = true;
            movingLeft = false;
            movingRight = false;

            direction = "down";
            moveTimer = 0f;
        }

        if (context.canceled)
        {
            movingDown = false;
        }
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            movingUp = false;
            movingDown = false;
            movingLeft = true;
            movingRight = false;

            direction = "left";
            moveTimer = 0f;
        }

        if (context.canceled)
        {
            movingLeft = false;
        }
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            movingUp = false;
            movingDown = false;
            movingLeft = false;
            movingRight = true;

            direction = "right";
            moveTimer = 0f;
        }

        if (context.canceled)
        {
            movingRight = false;
        }
    }
}
