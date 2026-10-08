using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    Moving,
    Interacting,
    Paused
}

/// <summary>
/// Hub class for player, houses player state and stats
/// </summary>
public class PlayerController : MonoBehaviour
{
    // References
    [SerializeField] PlayerInteraction interactRef;
    [SerializeField] public UnityEngine.UI.Slider HPSlider;
    [SerializeField] public UnityEngine.UI.Slider MPSlider;
    [SerializeField] LayerMask mask;
    [SerializeField] public int HP; // Player Hit Points
    [SerializeField] public int MP; // Player Magic Points
    [SerializeField] public int MaxHP; // Hit Points
    [SerializeField] public int MaxMP; // Magic Points
    [SerializeField] public int DMG;
    [SerializeField] public int DMGVar;

    // Fields
    public string direction; // Direction
    public PlayerState pSt; // Player state (for the state machine)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = "up";
        pSt = PlayerState.Moving;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBars();

        if(pSt == PlayerState.Moving)
        {
            // Movement
            CheckRotation(direction);
        }
    }

    /// <summary>
    /// Rotates player based on direction
    /// </summary>
    /// <param name="d">Direction</param>
    void CheckRotation(string d)
    {
        switch (d)
        {
            case "up":
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;

            case "down":
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                break;

            case "left":
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;

            case "right":
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                break;
        }
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

    #region Movement Callbacks
    // Movement Callbacks
    public void MoveUp(InputAction.CallbackContext context)
    {
        if (pSt == PlayerState.Moving)
        {
            if (context.started)
            {
                direction = "up";
            }
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (pSt == PlayerState.Moving)
        {
            if (context.started)
            {
                direction = "down";
            }
        }
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (pSt == PlayerState.Moving)
        {
            if (context.started)
            {
                direction = "left";
            }
        }
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (pSt == PlayerState.Moving)
        {
            if (context.started)
            {
                direction = "right";
            }
        }
    }
    #endregion
}
