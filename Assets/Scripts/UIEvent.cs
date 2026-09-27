using System;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    // References


    // Fields
    public GameObject targetObject;
    public string choice;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFight()
    {
        choice = "fight";
        switch (targetObject.tag)
        {
            case "Interactable":
                targetObject.GetComponent<Interactable>().ReturnResult(choice);
                break;

            case "NPC":
                targetObject.GetComponent<NPC>().ReturnResult(choice);
                break;

            case "Enemy":
                targetObject.GetComponent<Enemy>().ReturnResult(choice);
                break;
        }
        // Bring to menu
    }

    public void OnMagic()
    {
        choice = "magic";
        switch (targetObject.tag)
        {
            case "Interactable":
                targetObject.GetComponent<Interactable>().ReturnResult(choice);
                break;

            case "NPC":
                targetObject.GetComponent<NPC>().ReturnResult(choice);
                break;

            case "Enemy":
                targetObject.GetComponent<Enemy>().ReturnResult(choice);
                break;
        }
        // Bring to menu
    }

    public void OnAction()
    {
        choice = "action";
        switch (targetObject.tag)
        {
            case "Interactable":
                targetObject.GetComponent<Interactable>().ReturnResult(choice);
                break;

            case "NPC":
                targetObject.GetComponent<NPC>().ReturnResult(choice);
                break;

            case "Enemy":
                targetObject.GetComponent<Enemy>().ReturnResult(choice);
                break;
        }
        // Bring to menu
    }

    public void OnRun()
    {
        this.gameObject.SetActive(false);
    }
}