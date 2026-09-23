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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = "up";
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        transform.position = currentPosition;
        CheckRotation(direction);
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

    // Movement Callbacks
    public void MoveUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            direction = "up";

            if (DetectObstacle(new Vector2(0.0f, 1.0f)))
            {
                currentPosition = (Vector2)transform.position + new Vector2(0f, 1.0f);
            }
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            direction = "down";

            if (DetectObstacle(new Vector2(0.0f, -1.0f)))
            {
                currentPosition = (Vector2)transform.position + new Vector2(0f, -1.0f);
            }
        }
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            direction = "left";

            if (DetectObstacle(new Vector2(-1.0f, 0.0f)))
            {
                currentPosition = (Vector2)transform.position + new Vector2(-1.0f, 0f);
            }
        }
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            direction = "right";

            if (DetectObstacle(new Vector2(1.0f, 0.0f)))
            {
                currentPosition = (Vector2)transform.position + new Vector2(1.0f, 0f);
            }
        }
    }
}
