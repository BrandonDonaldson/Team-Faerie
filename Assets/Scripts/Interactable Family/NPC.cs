using NUnit.Framework;
using UnityEngine;

public class NPC : Interactable
{
    // References
    [SerializeField] string randomizedDialogue;

    // Fields
    string[] parsedRandom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStartUp();
        
        if (randomizedDialogue != null)
        {
            parsedRandom = randomizedDialogue.Split('|');
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ReturnResult(MenuState category, int action)
    {
        base.ReturnResult(category, action);

        if (parsedRandom != null && category == MenuState.Action && action == 2)
        {
            InterfaceRef.UpdateText(parsedRandom[Random.Range(0, parsedRandom.Length)]);
        }
    }
}
