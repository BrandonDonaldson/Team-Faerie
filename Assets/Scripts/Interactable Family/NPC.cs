using UnityEngine;

public class NPC : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ReturnResult(MenuState category, int action)
    {
        if (category == MenuState.Fight)
        {
            InterfaceRef.UpdateText("What are you doing? Violence isn't the answer!");
        }

        if (category == MenuState.Magic)
        {
            InterfaceRef.UpdateText("What are you doing? Violence isn't the answer!");
        }

        if (category == MenuState.Action)
        {
            switch (action)
            {
                case 1:
                    InterfaceRef.UpdateText("This is ClassicNPC. HP: 10, ATK: 1");
                    break;

                case 2:
                    InterfaceRef.UpdateText("\"Hello! I'm ClassicNPC!\"");
                    break;

                case 3:
                    InterfaceRef.UpdateText("I don't know what you're trying to do, but it clearly didn't work.");
                    break;
            }
        }
    }
}
