using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // References
    [SerializeField] UIEvent InterfaceRef;
    [SerializeField] BoxCollider2D collider;
    [SerializeField] LayerMask mask;
    
    // Fields
    string[] results;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                    InterfaceRef.UpdateText("GenericInteractable does not bother himself with needless fights");
                    break;

                case 2:
                    InterfaceRef.UpdateText("GenericInteractable does not bother himself with needless fights");
                    break;

                case 3:
                    InterfaceRef.UpdateText("GenericInteractable does not bother himself with needless fights");
                    break;
            }
        }

        if (category == MenuState.Fight)
        {
            switch (action)
            {
                case 1:
                    InterfaceRef.UpdateText("All magic is ineffective against GenericInteractable");
                    break;

                case 2:
                    InterfaceRef.UpdateText("All magic is ineffective against GenericInteractable");
                    break;

                case 3:
                    InterfaceRef.UpdateText("All magic is ineffective against GenericInteractable");
                    break;
            }
        }

        if (category == MenuState.Fight)
        {
            switch (action)
            {
                case 1:
                    InterfaceRef.UpdateText("GenericInteractable is a GenericInteractable. 9000 HP, 9000 ATK");
                    break;

                case 2:
                    InterfaceRef.UpdateText("GenericInteractable is a GenericInteractable. 9000 HP, 9000 ATK");
                    break;

                case 3:
                    InterfaceRef.UpdateText("GenericInteractable is a GenericInteractable. 9000 HP, 9000 ATK");
                    break;
            }
        }
    }

    public void Offload()
    {

    }


}
