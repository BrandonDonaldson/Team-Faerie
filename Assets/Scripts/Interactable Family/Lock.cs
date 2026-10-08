using UnityEngine;
using UnityEngine.InputSystem;

public class Lock : Interactable
{
    [SerializeField] PuzzleLogic puzzleManager;
    [SerializeField] string solutionCode;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStartUp();
        puzzleManager.code = this.solutionCode;
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
            InterfaceRef.ToggleLock();
        }
    }
}
