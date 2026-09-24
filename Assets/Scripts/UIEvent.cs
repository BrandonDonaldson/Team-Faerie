using System;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    // References


    // Fields
    public Interactable targetObject;
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
        targetObject.ReturnResult(choice);
        // Bring to menu
    }

    public void OnMagic()
    {
        choice = "magic";
        targetObject.ReturnResult(choice);
        // Bring to menu
    }

    public void OnAction()
    {
        choice = "action";
        targetObject.ReturnResult(choice);
        // Bring to menu
    }

    public void OnRun()
    {
        this.gameObject.SetActive(false);
    }
}