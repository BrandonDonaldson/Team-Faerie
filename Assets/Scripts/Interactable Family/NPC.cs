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

    public override void ReturnResult(string action)
    {
        switch (action)
        {
            case "fight":
                Debug.Log("Do you really want to fight them?");
                break;

            case "magic":
                Debug.Log("Seems a little excessive, don't you think?");
                break;

            case "action":
                Debug.Log("This is GenericNPC. Be nice to them. 10 HP, 10 ATK");
                break;
        }
    }
}
