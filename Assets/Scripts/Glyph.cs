using UnityEngine;

public class Glyph : MonoBehavior
{
    [SerializeField] PuzzleLogic puzzleRef;
    [SerializeField] SpriteRenderer centerRef;
    [SerializeField] int magicType;

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

}
