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

    public virtual void ReturnResult(string action)
    {
        switch(action)
        {
            case "fight":
                Debug.Log("GenericInteractable does not bother himself with needless fights");
                break;

            case "magic":
                Debug.Log("All magic is ineffective against GenericInteractable");
                break;

            case "action":
                Debug.Log("GenericInteractable is a GenericInteractable. 9000 HP, 9000 ATK");
                break;
        }
    }

    public void Offload()
    {

    }


}
