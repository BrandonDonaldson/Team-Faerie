using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum PuzzleType
{
    Pillars
}

public class PuzzleLogic : MonoBehaviour
{
    [SerializeField] UIEvent InterfaceRef;
    [SerializeField] PuzzleType type;
    [SerializeField] GameObject obstacleRef;
    [SerializeField] bool solved;

    List<GameObject> objectContainers;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        solved = false;
        List<GameObject> objectContainers = new List<GameObject>();
        switch (type)
        {
            case PuzzleType.Pillars:
                Pillar[] pillars = this.GetComponentsInChildren<Pillar>();
                for (int i = 0; i < pillars.Length; i++)
                {
                    objectContainers.Add(pillars[i].gameObject);
                }

                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (solved)
        {
            obstacleRef.SetActive(false);
            InterfaceRef.ExtendText("\n\nYou hear something open up nearby...");
        }
    }

    public void CheckSolution()
    {
        switch (type)
        {
            case PuzzleType.Pillars:
                for (int i = 0; i < objectContainers.Count; i++)
                {
                    if (!objectContainers[i].GetComponent<Pillar>().isSolved)
                    {
                        break;
                    }
                }
                solved = true;
                break;

            default:
                break;
        }
    }
}
