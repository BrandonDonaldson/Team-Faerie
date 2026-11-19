using UnityEngine;

public class BoxResetter : Interactable
{
    // Reference
    [SerializeField] MovingBox targetBox;
    [SerializeField] public PuzzleLogic puzzleManager;
    
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
            targetBox.gameObject.GetComponent<Transform>().position = targetBox.startingPosition;
            InterfaceRef.UpdateText("A gust of wind blows through the room, the box reappearing in it's original spot.");
        }
    }
}
