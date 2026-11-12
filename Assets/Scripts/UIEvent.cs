using System;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] GameObject textBoxGroup;
    [SerializeField] GameObject menuControl;
    [SerializeField] GameObject lockUI;
    [SerializeField] GameObject sliderBox;
    [SerializeField] GameObject radialMenu;
    //[SerializeField] Slider HPImageRef;
    //[SerializeField] Slider MPImageRef;
    [SerializeField] Image HPImageRef;
    [SerializeField] Image MPImageRef;

    // Fields
    public GameObject targetObject;
    public Transform[] buttonTransforms;
    public MenuState category;
    public int choice;
    private Button[] buttonList;
    public bool waitingOnText;

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
        if (waitingOnText)
        {
            waitingOnText = !Input.anyKey;
        }
        else
        {
            textBoxGroup.SetActive(false);
        }
    }

    #region MenuButtons

    public void SetMenu()
    {
        buttonList = radialMenu.GetComponentsInChildren<Button>();
        Debug.Log(buttonList.Length);
        // Fight, Fire, Wind, Light, Info, Talk, Act(?)

        if (targetObject)
        {
            switch (targetObject.tag)
            {
                case "Interactable":
                    buttonList[0].interactable = true;
                    buttonList[1].interactable = true;
                    buttonList[2].interactable = true;
                    buttonList[3].interactable = true;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = true;
                    sliderBox.SetActive(false);
                    break;

                case "NPC":
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = false;
                    buttonList[2].interactable = false;
                    buttonList[3].interactable = false;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = true;
                    sliderBox.SetActive(false);
                    break;

                case "Enemy":
                    targetObject.GetComponent<Enemy>().HPImage = HPImageRef;
                    targetObject.GetComponent<Enemy>().MPImage = MPImageRef;
                    buttonList[0].interactable = true;
                    buttonList[1].interactable = true;
                    buttonList[2].interactable = true;
                    buttonList[3].interactable = true;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = true;
                    sliderBox.SetActive(true);
                    break;

                case "Tree":
                    buttonList[0].interactable = true;
                    buttonList[1].interactable = false;
                    buttonList[2].interactable = false;
                    buttonList[3].interactable = false;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = true;
                    sliderBox.SetActive(false);
                    break;

                case "Rat":
                    targetObject.GetComponent<Rat>().HPImage = HPImageRef;
                    targetObject.GetComponent<Rat>().MPImage = MPImageRef;
                    buttonList[0].interactable = true;
                    buttonList[1].interactable = true;
                    buttonList[2].interactable = true;
                    buttonList[3].interactable = true;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = true;
                    sliderBox.SetActive(true);
                    break;

                case "Totem":
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = false;
                    buttonList[2].interactable = false;
                    buttonList[3].interactable = false;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = true;
                    sliderBox.SetActive(false);
                    break;

                case "Pillar":
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = true;
                    buttonList[2].interactable = true;
                    buttonList[3].interactable = true;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = true;
                    sliderBox.SetActive(false);
                    break;

                case "Lock":
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = false;
                    buttonList[2].interactable = false;
                    buttonList[3].interactable = false;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = !targetObject.GetComponent<Lock>().puzzleManager.solved;
                    sliderBox.SetActive(false);
                    break;

                case "MovingBox":
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = true;
                    buttonList[2].interactable = !targetObject.GetComponent<MovingBox>().puzzleManager.solved;
                    buttonList[3].interactable = true;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = true;
                    sliderBox.SetActive(false);
                    break;

                case "BoxResetter":
                    buttonList[0].interactable = false;
                    buttonList[1].interactable = false;
                    buttonList[2].interactable = false;
                    buttonList[3].interactable = false;
                    buttonList[4].interactable = true;
                    buttonList[5].interactable = true;
                    buttonList[6].interactable = !targetObject.GetComponent<BoxResetter>().puzzleManager.solved;
                    sliderBox.SetActive(false);
                    break;
            }
        }
        else
        {
            UpdateText("There's nothing there?");
        }
    }

    // Calls for the results depending on object tab
    public void CallForResult()
    {
        buttonList = radialMenu.GetComponentsInChildren<Button>();
        // Fight, Fire, Wind, Light, Info, Talk, Act(?)

        if (targetObject)
        {
            textBoxGroup.SetActive(true);
            waitingOnText = true;

            switch (targetObject.tag)
            {
                case "Interactable":
                    targetObject.GetComponent<Interactable>().ReturnResult(category, choice);
                    break;

                case "NPC":
                    targetObject.GetComponent<NPC>().ReturnResult(category, choice);
                    break;

                case "Enemy":
                    targetObject.GetComponent<Enemy>().ReturnResult(category, choice);
                    break;

                case "Tree":
                    targetObject.GetComponent<Tree>().ReturnResult(category, choice);
                    break;

                case "Rat":
                    targetObject.GetComponent<Rat>().ReturnResult(category, choice);
                    break;

                case "Totem":
                    targetObject.GetComponent<Totem>().ReturnResult(category, choice);
                    break;

                case "Pillar":
                    targetObject.GetComponent<Pillar>().ReturnResult(category, choice);
                    break;

                case "Lock":
                    targetObject.GetComponent<Lock>().ReturnResult(category, choice);
                    break;

                case "MovingBox":
                    targetObject.GetComponent<MovingBox>().ReturnResult(category, choice);
                    break;

                case "BoxResetter":
                    targetObject.GetComponent<BoxResetter>().ReturnResult(category, choice);
                    break;
            }
        }
        else
        {
            UpdateText("There's nothing there?");
        }
    }

    // Code for back/run (bottom right)
    //public void BackButton()
    //{
    //    choice = 4;
    //    if (category != MenuState.Top)
    //    {
    //        category = MenuState.Top;
    //        CallForResult();
    //    }
    //    else
    //    {
    //        if (!targetObject)
    //        {
    //            this.gameObject.SetActive(false);
    //            PlyrCtrl.pSt = PlayerState.Moving;
    //            UpdateText("");
    //        }
    //        else
    //        {
    //            switch (targetObject.tag)
    //            {
    //                case "Enemy":
    //                    if (UnityEngine.Random.Range(0, 10) == 0) // 10% Failure to Run
    //                    {
    //                        UpdateText("You couldn't get away!");
    //                    }
    //                    else
    //                    {
    //                        this.gameObject.SetActive(false);
    //                        PlyrCtrl.pSt = PlayerState.Moving;
    //                        UpdateText("");
    //                    }
    //                    break;

    //                case "Rat":
    //                    if (UnityEngine.Random.Range(0, 5) == 0) // 20% Failure to Run
    //                    {
    //                        UpdateText("You couldn't get away!");
    //                    }
    //                    else
    //                    {
    //                        this.gameObject.SetActive(false);
    //                        PlyrCtrl.pSt = PlayerState.Moving;
    //                        UpdateText("");
    //                    }
    //                    break;

    //                case "Infected":
    //                    if (UnityEngine.Random.Range(0, 3) == 0) // 33% Failure to Run
    //                    {
    //                        UpdateText("You couldn't get away!");
    //                    }
    //                    else
    //                    {
    //                        this.gameObject.SetActive(false);
    //                        PlyrCtrl.pSt = PlayerState.Moving;
    //                        UpdateText("");
    //                    }
    //                    break;

    //                default:
    //                    this.gameObject.SetActive(false);
    //                    PlyrCtrl.pSt = PlayerState.Moving;
    //                    UpdateText("");
    //                    break;
    //            }
    //        }
    //    }
    //}
#endregion

    #region StatMethods
    // Stat-related Methods
    public int DealDamage(string enemy, MenuState category, int choice)
    {    
        int rolledDamage = UnityEngine.Random.Range(PlyrCtrl.DMG - PlyrCtrl.DMGVar, PlyrCtrl.DMG + PlyrCtrl.DMGVar + 1); // Rolls a random value for damage

        if (category == MenuState.Magic)
        {
            if (PlyrCtrl.MP > 0)
            {
                switch(choice)
                {
                    case 1: // Fire
                        if (enemy == "rat")
                        {
                            rolledDamage = (int)(rolledDamage * 3);
                        }
                        else
                        {
                            rolledDamage = (int)(rolledDamage * 2);
                        }
                            
                        SpendMana(2);
                        break;

                    case 2: // Wind
                        rolledDamage = (int)(rolledDamage * 1.5);
                        SpendMana(1);
                        break;

                    case 3: // Light
                        if (enemy == "infected")
                        {
                            rolledDamage = (int)(rolledDamage * 3);
                        }
                        else
                        {
                            rolledDamage = (int)(rolledDamage * 2);
                        }

                        SpendMana(2);
                        break;
                }
                rolledDamage *= 2;
                SpendMana(2);
            }
            else
            {
                if (PlyrCtrl.MP == 0)
                {
                    return 0;
                }
            }
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
    /// <summary>
    /// Switches between showing lock and showing menu
    /// </summary>
    public void ToggleLock()
    {
        if (!lockUI.active)
        {
            lockUI.SetActive(true);
            menuControl.SetActive(false);
        }
        else
        {
            lockUI.SetActive(false);
            menuControl.SetActive(true);
            Button[] buttonList = radialMenu.GetComponentsInChildren<Button>();
            buttonList[6].interactable = !targetObject.GetComponent<Lock>().puzzleManager.solved;
            category = MenuState.Top;
        }
    }
    #endregion
}