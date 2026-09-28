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

    public override void ReturnResult(MenuState category, int action)
    {
        switch (action)
        {
            case 1:
                Debug.Log("The rat does not like being hit.");
                break;

            case 2:
                Debug.Log("The rat does not like getting magic'd.");
                break;

            case 3:
                Debug.Log("The rat doesn't like being acted upon. HP 5. ATK 10.");
                break;
        }
    }
}
