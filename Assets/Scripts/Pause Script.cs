using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] PlayerController PlyrCtrl;


    private PlayerState playerStateBfrPause;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        // If the player is already paused
        if (PlyrCtrl.pSt == PlayerState.Paused)
        {
            // Unpause
            PlyrCtrl.pSt = playerStateBfrPause;
            pauseMenu.SetActive(false);

            // If was interacting before pause, open interaction menu
            if(playerStateBfrPause == PlayerState.Interacting)
            {
                menuCanvas.SetActive(true);
            }
        }
        else
        {
            // Pause
            // Keep track of previous player state before pausing
            playerStateBfrPause = PlyrCtrl.pSt;
            PlyrCtrl.pSt = PlayerState.Paused;
            pauseMenu.SetActive(true);
            menuCanvas.SetActive(false);
        }
    }
}
