using UnityEngine;

public class Enemy : Interactable
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
                Debug.Log("The rat does not like being hit.");
                break;

            case "magic":
                Debug.Log("The rat does not like getting magic'd.");
                break;

            case "action":
                Debug.Log("The rat doesn't like being acted upon. HP 5. ATK 10.");
                break;
        }
    }
}
