using UnityEngine;

public class Pillar : Interactable
{
    [SerializeField] PuzzleLogic puzzleRef;
    [SerializeField] int magicType;
    [SerializeField] Color32 solvedColor;
    
    public bool isSolved;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStartUp();
        isSolved = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ReturnResult(MenuState category, int action)
    {
        base.ReturnResult(category, action);

        if (category == MenuState.Magic && action == magicType)
        {
            InterfaceRef.UpdateText("The magic lights up the pillar.");
            GetComponent<SpriteRenderer>().color = solvedColor;
            isSolved = true;
            puzzleRef.CheckSolution();
        }
    }
}
