using Mono.Cecil.Cil;
using UnityEngine;

public class Rat : Enemy
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStartUp();
    }

    // Update is called once per frame
    void Update()
    {   
        UpdateBars();
    }

    public override void ReturnResult(MenuState category, int action)
    {
        base.ReturnResult(category, action);

        // Checks for Incoming Damage
        if (category == MenuState.Fight || category == MenuState.Magic)
        {
            int incomingDamage = InterfaceRef.DealDamage(category);
            InterfaceRef.ExtendText(" " + incomingDamage + " damage!");
            HP -= incomingDamage;
        }

        UpdateBars();

        // Attack/Death Behavior
        if (category != MenuState.Top)
        {
            Behavior();
        }
    }

    private void Behavior()
    {
        if (HP > 0)
        {
            int rolledDamage = UnityEngine.Random.Range(damage - 2, damage + 2);
            InterfaceRef.TakeDamage(rolledDamage);

            string damageText = "\n\nThe rat bites back for " + rolledDamage + " damage!";
            if (rolledDamage > 1)
            {
                damageText += " YEOWCH!";
            }
            else
            {
                damageText += " Um...Ouch?";
            }
            InterfaceRef.ExtendText(damageText);
        }
        else
        {
            InterfaceRef.ExtendText("\n\nThe rat falls over, convulsing, before [GENERIC GRAPHIC DEATH].");
            Offload();
        }
    }
}
