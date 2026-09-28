using UnityEngine;

public class Tree : Interactable
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
            InterfaceRef.UpdateText("You cut the tree!");
            Offload();
        }

        if (category == MenuState.Magic)
        {
            InterfaceRef.UpdateText("Seems a bit excessive, don't you think?");
        }

        if (category == MenuState.Action)
        {
            switch (action)
            {
                case 1:
                    InterfaceRef.UpdateText("This is a tree.");
                    break;

                case 2:
                    InterfaceRef.UpdateText("\"...\"");
                    break;
                    
                case 3:
                    InterfaceRef.UpdateText("You push against the tree, but nothing happens. Feels like you'll need more force to get rid of it.");
                    break;
            }
        }
    }

    public void Offload()
    {
        Destroy(this.gameObject);
    }
}
