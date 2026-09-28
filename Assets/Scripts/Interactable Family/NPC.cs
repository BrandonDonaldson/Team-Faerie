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
        switch (action)
        {
            case 1:
                Debug.Log("Do you really want to fight them?");
                break;

            case 2:
                Debug.Log("Seems a little excessive, don't you think?");
                break;

            case 3:
                Debug.Log("This is GenericNPC. Be nice to them. 10 HP, 10 ATK");
                break;
        }
    }
}
