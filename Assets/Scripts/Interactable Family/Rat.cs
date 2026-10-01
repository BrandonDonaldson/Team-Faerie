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
        
    }

    public override void ReturnResult(MenuState category, int action)
    {
        base.ReturnResult(category, action);

        switch(category)
        {
            case MenuState.Fight:

                break;

            case MenuState.Magic:

                break;
        }

        if (HP > 0)
        {
            int rolledDamage = UnityEngine.Random.Range(damage-2, damage+2);
            InterfaceRef.TakeDamage(rolledDamage);
            InterfaceRef.ExtendText("The rat bites back for " + rolledDamage + " damage! Yeowch!");
        }
        else
        {
            InterfaceRef.ExtendText("The rat falls over, convulsing, before [GENERIC GRAPHIC DEATH].");
        }
    }
}
