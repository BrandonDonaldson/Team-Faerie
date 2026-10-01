using UnityEngine;

public class Totem : Interactable
{
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
            InterfaceRef.Restore(15, 15);
        }
    }
}
