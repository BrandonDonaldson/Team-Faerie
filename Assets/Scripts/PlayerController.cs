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
    [SerializeField] public UnityEngine.UI.Image HPImage;
    [SerializeField] public UnityEngine.UI.Image MPImage;
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
    // Updates HP and MP Image
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
    private void CheckHP()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
}
