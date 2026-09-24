using Unity.VisualScripting;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //references
    [SerializeField] BoxCollider2D collider;
    [SerializeField] LayerMask mask;


}
