using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    public PlayerState pSt; // Player state (for the state machine)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pSt = PlayerState.Moving;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBars();
        CheckHP();
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
    private void CheckHP()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
}
