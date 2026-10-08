using NUnit.Framework;
using UnityEngine;

public class NPC : Interactable
{
    // References
    [SerializeField] string loopedDialogue;

    // Fields
    string[] parsedLoop;
    [SerializeField] int dialogueIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStartUp();
        
        if (loopedDialogue != null)
        {
            parsedLoop = loopedDialogue.Split('|');
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ReturnResult(MenuState category, int action)
    {
        // Resets back to the First Dialogue option if you leave
        if (category == MenuState.Top)
        {
            dialogueIndex = 0;
        }

        base.ReturnResult(category, action);

        if (parsedLoop != null && category == MenuState.Action && action == 2)
        {
            // Updates the text to the index of the dialogue
            InterfaceRef.UpdateText(parsedLoop[dialogueIndex]);
            
            // Concat
            dialogueIndex++;

            // if it reaches the end of the string array, to back to the first Dialogue
            if (dialogueIndex == parsedLoop.Length)
            {
                dialogueIndex = 0;
            }
        }
    }
}
