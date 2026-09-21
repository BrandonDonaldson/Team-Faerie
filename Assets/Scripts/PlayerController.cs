using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{

    // Fields
    string direction;
    Vector2 currentPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        transform.position = currentPosition;
    }

    // Movement Callbacks
    public void MoveUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            direction = "up";
            currentPosition = (Vector2)transform.position + new Vector2(0f, 1.0f);
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            direction = "down";
            currentPosition = (Vector2)transform.position + new Vector2(0f, -1.0f);
        }
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            direction = "left";
            currentPosition = (Vector2)transform.position + new Vector2(-1.0f, 0f);
        }
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            direction = "right";
            currentPosition = (Vector2)transform.position + new Vector2(1.0f, 0f);
        }
    }
}
