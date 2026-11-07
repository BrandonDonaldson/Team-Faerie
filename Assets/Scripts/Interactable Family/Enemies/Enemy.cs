using UnityEngine;
using UnityEngine.UI;

public class Enemy : Interactable
{
    [SerializeField] public Image HPImage;
    [SerializeField] public Image MPImage;
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
        
        float targetHPFillAmount = (float)HP / (float)MaxHP;
        float targetMPFillAmount = (float)MP / (float)MaxMP;

        HPImage.fillAmount = targetHPFillAmount;
        MPImage.fillAmount = targetMPFillAmount;
    }
}
