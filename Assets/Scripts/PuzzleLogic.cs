using System.Collections;
using UnityEngine;

enum PuzzleType
{
    Pillars
}

public class PuzzleLogic : MonoBehaviour
{
    [SerializeField] PuzzleType type;


    GameObject[] objectContainers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (type)
        {
            case PuzzleType.Pillars:
                Transform[] transforms = this.GetComponentsInChildren<Transform>();
                for (int i = 0; i < transforms.Length; i++)
                {

                }
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
