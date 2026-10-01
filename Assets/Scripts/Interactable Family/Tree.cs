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
        base.ReturnResult(category, action);
        
        if (category == MenuState.Fight)
        {
            InterfaceRef.UpdateText("You cut the tree!");
            Offload();
        }
    }

    public void Offload()
    {
        Destroy(this.gameObject);
    }
}
