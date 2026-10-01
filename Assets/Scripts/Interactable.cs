using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // References
    [SerializeField] public UIEvent InterfaceRef;
    [SerializeField] BoxCollider2D collider;
    [SerializeField] LayerMask mask;
    [SerializeField] string fightDialogue;
    [SerializeField] string magicDialogue;
    [SerializeField] string actionDialogue;

    // Fields
    List<string> results;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       if (fightDialogue != null)
       {
            string[] parsedDialogue = fightDialogue.Split('|');
            for (int i = 0; i < parsedDialogue.Length; i++)
            {
                results.Add(parsedDialogue[i]);
            }
       }
       else
       {
            for (int i = 0; i < 3; i++)
            {
                results.Add("Fight text here");
            }
       }

        if (magicDialogue != null)
        {
            string[] parsedDialogue = magicDialogue.Split('|');
            for (int i = 0; i < parsedDialogue.Length; i++)
            {
                results.Add(parsedDialogue[i]);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                results.Add("Magic text here");
            }
        }

        if (actionDialogue != null)
        {
            string[] parsedDialogue = actionDialogue.Split('|');
            for (int i = 0; i < parsedDialogue.Length; i++)
            {
                results.Add(parsedDialogue[i]);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                results.Add("Other text here");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ReturnResult(MenuState category, int action)
    {
        if (category == MenuState.Fight)
        {   
            switch (action)
            {
                case 1:
                    InterfaceRef.UpdateText(results[0]);
                    break;

                case 2:
                    InterfaceRef.UpdateText(results[1]);
                    break;

                case 3:
                    InterfaceRef.UpdateText(results[2]);
                    break;
            }
        }

        if (category == MenuState.Magic)
        {
            switch (action)
            {
                case 1:
                    InterfaceRef.UpdateText(results[3]);
                    break;

                case 2:
                    InterfaceRef.UpdateText(results[4]);
                    break;

                case 3:
                    InterfaceRef.UpdateText(results[5]);
                    break;
            }
        }

        if (category == MenuState.Action)
        {
            switch (action)
            {
                case 1:
                    InterfaceRef.UpdateText(results[6]);
                    break;

                case 2:
                    InterfaceRef.UpdateText(results[7]);
                    break;

                case 3:
                    InterfaceRef.UpdateText(results[8]);
                    break;
            }
        }
    }

    public void Offload()
    {
        Destroy(this.gameObject);
    }
}
