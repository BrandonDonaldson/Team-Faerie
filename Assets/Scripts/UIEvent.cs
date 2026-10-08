using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.Collections;
using UnityEngine.UI;

public enum MenuState
{
    Top,
    Fight,
    Magic,
    Action
}

public class UIEvent : MonoBehaviour
{
    // References
    [SerializeField] PlayerController PlyrCtrl;
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] GameObject lockUI;
    [SerializeField] GameObject topMenu;
    [SerializeField] GameObject fightMenu;
    [SerializeField] GameObject magicMenu;
    [SerializeField] GameObject actionMenu;
    [SerializeField] Slider HPSliderRef;
    [SerializeField] Slider MPSliderRef;

    // Fields
    public GameObject targetObject;
    public Transform[] buttonTransforms;
    public MenuState category;
    public int choice;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        category = MenuState.Top;
        lockUI.SetActive(false);
        choice = 4;
    }

    // Update is called once per frame
    void Update()
    {
        SetMenu();
    }

    #region MenuButtons
    // Code for Button 1 (top left)
    public void Button1()
    {
        if (category != MenuState.Top)
        {
            choice = 1;
            CallForResult();
        }
        else
        {
            category = MenuState.Fight;
        }
    }

    // Code for Button 2 (top right)
    public void Button2()
    {
        if (category != MenuState.Top)
        {
            choice = 2;
            CallForResult();
        }
        else
        {
            category = MenuState.Magic;
        }
    }

    // Code for Button 3 (bottom left)
    public void Button3()
    {
        if (category != MenuState.Top)
        {
            choice = 3;
            CallForResult();
        }
        else
        {
            category = MenuState.Action;
        }
    }

    // Calls for the results depending on object tab
    public void CallForResult()
    {
        Button[] buttonList = topMenu.GetComponentsInChildren<Button>();
        buttonList[3].interactable = true;
        
        if (targetObject)
        {
            switch (targetObject.tag)
            {
                case "Interactable":
                    targetObject.GetComponent<Interactable>().ReturnResult(category, choice);
                    buttonList[0].interactable = true;
                    buttonList[1].interactable = true;
                    buttonList[2].interactable = true;
                    break;

                case "NPC":
                    targetObject.GetComponent<NPC>().ReturnResult(category, choice);
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = false;
                    buttonList[2].interactable = true;
                    break;

                case "Enemy":
                    targetObject.GetComponent<Enemy>().ReturnResult(category, choice);
                    targetObject.GetComponent<Enemy>().HPSlider = HPSliderRef;
                    targetObject.GetComponent<Enemy>().MPSlider = MPSliderRef;
                    buttonList[0].interactable = true;
                    buttonList[1].interactable = true;
                    buttonList[2].interactable = true;
                    break;

                case "Tree":
                    targetObject.GetComponent<Tree>().ReturnResult(category, choice);
                    buttonList[0].interactable = true;
                    buttonList[1].interactable = false;
                    buttonList[2].interactable = true;
                    break;

                case "Rat":
                    targetObject.GetComponent<Rat>().ReturnResult(category, choice);
                    targetObject.GetComponent<Rat>().HPSlider = HPSliderRef;
                    targetObject.GetComponent<Rat>().MPSlider = MPSliderRef;
                    buttonList[0].interactable = true;
                    buttonList[1].interactable = true;
                    buttonList[2].interactable = true;
                    break;

                case "Totem":
                    targetObject.GetComponent<Totem>().ReturnResult(category, choice);
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = false;
                    buttonList[2].interactable = true;
                    break;

                case "Pillar":
                    targetObject.GetComponent<Pillar>().ReturnResult(category, choice);
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = true;
                    buttonList[2].interactable = true;
                    break;

                case "Lock":
                    targetObject.GetComponent<Lock>().ReturnResult(category, choice);
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = false;
                    buttonList[2].interactable = true;
                    break;
            }
        }
        else
        {
            UpdateText("There's nothing there?");
        }
    }

    // Code for back/run (bottom right)
    public void BackButton()
    {
        if (category != MenuState.Top)
        {
            category = MenuState.Top;
            choice = 4;
            CallForResult();
        }
        else
        {
            this.gameObject.SetActive(false);
            PlyrCtrl.pSt = PlayerState.Moving;
            UpdateText("");
            choice = 4;
        }
    }

    // Sets the menu
    public void SetMenu()
    {
        switch (category)
        {
            case MenuState.Top:
                topMenu.SetActive(true);
                fightMenu.SetActive(false);
                magicMenu.SetActive(false);
                actionMenu.SetActive(false);
                break;

            case MenuState.Fight:
                topMenu.SetActive(false);
                fightMenu.SetActive(true);
                magicMenu.SetActive(false);
                actionMenu.SetActive(false);
                break;

            case MenuState.Magic:
                topMenu.SetActive(false);
                fightMenu.SetActive(false);
                magicMenu.SetActive(true);
                actionMenu.SetActive(false);
                break;

            case MenuState.Action:
                topMenu.SetActive(false);
                fightMenu.SetActive(false);
                magicMenu.SetActive(false);
                actionMenu.SetActive(true);
                break;
        }
    }
#endregion

    #region StatMethods
    // Stat-related Methods
    public int DealDamage(MenuState category)
    {    
        int rolledDamage = UnityEngine.Random.Range(PlyrCtrl.DMG - PlyrCtrl.DMGVar, PlyrCtrl.DMG + PlyrCtrl.DMGVar + 1);

        if (category == MenuState.Magic)
        {
            rolledDamage *= 2;
            SpendMana(2);
        }

        return rolledDamage;
    }

    
    public void TakeDamage(int damage)
    {
        PlyrCtrl.HP -= damage;
    }

    public void SpendMana(int mana)
    {
        PlyrCtrl.MP -= mana;
    }

    public void Restore(int health, int mana)
    {
        PlyrCtrl.HP += health;
        if (PlyrCtrl.HP > PlyrCtrl.MaxHP)
        {
            PlyrCtrl.HP = PlyrCtrl.MaxHP;
        }

        PlyrCtrl.MP += mana;
        if (PlyrCtrl.MP > PlyrCtrl.MaxMP)
        {
            PlyrCtrl.MP = PlyrCtrl.MaxMP;
        }
    }

    // Update text
    public void UpdateText(string newText)
    {
        textBox.text = newText;
    }

    // Extend text
    public void ExtendText(string moreText)
    {
        textBox.text += moreText;
    }
    #endregion

    #region LockUI
    public void ToggleLock()
    {
        if (!lockUI.active)
        {
            lockUI.SetActive(true);
        }
        else
        {
            lockUI.SetActive(false);
        }
    }
    #endregion
}