using UnityEngine;
using UnityEngine.UI;

public class Enemy : Interactable
{
    [SerializeField] public Slider HPSlider;
    [SerializeField] public Slider MPSlider;
    [SerializeField] public int HP; // Hit Points
    [SerializeField] public int MP; // Magic Points
    [SerializeField] public int MaxHP; // Hit Points
    [SerializeField] public int MaxMP; // Magic Points
    [SerializeField] public int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStartUp();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Updates HP and MP Sliders
    public void UpdateBars()
    {
        if (HP < 0)
        {
            HP = 0;
        }

        if (MP < 0)
        {
            MP = 0;
        }
        
        HPSlider.value = (float)HP / (float)MaxHP;
        MPSlider.value = (float)MP / (float)MaxMP;
    }
}
