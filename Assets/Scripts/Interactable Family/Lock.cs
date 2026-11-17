using UnityEngine;
using UnityEngine.InputSystem;

public class Lock : Interactable
{
    [SerializeField] public PuzzleLogic puzzleManager;
    [SerializeField] public GameObject obstacleRef;
    [SerializeField] public string solutionCode;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStartUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ReturnResult(MenuState category, int action)
    {
        base.ReturnResult(category, action);
        if (category == MenuState.Action && action == 3)
        {
            // Sets UI on Action -> Act
            Debug.Log("Opening Lock Puzzle");
            InterfaceRef.ToggleLock();
        }
    }
}
