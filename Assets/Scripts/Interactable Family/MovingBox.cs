using System;
using UnityEngine;

public class MovingBox : Interactable
{
    // References
    [SerializeField] PlayerMovement plyrCtrl;
    [SerializeField] GameObject targetDestination;
    [SerializeField] public PuzzleLogic puzzleManager;
    [SerializeField] LayerMask collisionMask;

    // Fields
    [SerializeField] public Vector3 startingPosition;
    [SerializeField] Vector3 solvedPosition;
    [SerializeField] Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStartUp();
        solvedPosition = targetDestination.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (plyrCtrl.PlayerDirection)
        {
            case PlayerDirection.Up:
                direction = new Vector2(0.0f, 1.0f);
                break;

            case PlayerDirection.Down:
                direction = new Vector2(0.0f, -1.0f);
                break;

            case PlayerDirection.Left:
                direction = new Vector2(-1.0f, 0.0f);
                break;

            case PlayerDirection.Right:
                direction = new Vector2(1.0f, 0.0f);
                break;
        }
    }

    public override void ReturnResult(MenuState category, int action)
    {
        base.ReturnResult(category, action);
        if (category == MenuState.Magic && action == 2)
        {
            MoveUntilStop();
            InterfaceRef.UpdateText("The wind pushes the box.");
            if (transform.position == solvedPosition)
            {
                puzzleManager.CheckSolution();
            }
        }
        if (category == MenuState.Action && action == 1 && puzzleManager.solved)
        {
            InterfaceRef.UpdateText("The box no longer glows blue.");
        }
    }

    // Moves the box
    void MoveUntilStop()
    {
        while (!Physics2D.Raycast(transform.position + (Vector3)(2.0f * direction / 3.0f), direction, 0.33f, collisionMask))
        {
            Vector3 position = transform.position;
            position += new Vector3(direction.x, direction.y, 0.0f);
            transform.position = position;
        }
    }
}
