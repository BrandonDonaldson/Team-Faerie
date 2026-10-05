using UnityEngine;

public class Pillar : Interactable
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
    }
}
