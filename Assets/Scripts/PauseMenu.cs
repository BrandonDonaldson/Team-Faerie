using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] PlayerController PlyrCtrl;
    [SerializeField] GameObject interactionMenus;
    [SerializeField] GameObject pauseMenu;

    private PlayerState playerStateBfrPause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        RunThePause();
    }

    private void RunThePause()
    {
        // If the player is already paused
        if (PlyrCtrl.pSt == PlayerState.Paused)
        {
            // Unpause
            Unpause();
        }
        else
        {
            // Pause
            // Keep track of previous player state before pausing
            playerStateBfrPause = PlyrCtrl.pSt;
            PlyrCtrl.pSt = PlayerState.Paused;
            pauseMenu.SetActive(true);
            interactionMenus.SetActive(false);
        }
    }

    public void Unpause()
    {
        PlyrCtrl.pSt = playerStateBfrPause;
        pauseMenu.SetActive(false);
        interactionMenus.SetActive(true);
    }
}
