using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("References")]
    public HUDController hud;
    public EndScreenController endScreen;
    public ChaosSystem chaosSystem; // Optional direct reference (auto-updates HUD)

    [HideInInspector] public bool gameActive = true;
    private bool gameEnded = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        gameActive = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (hud != null)
            hud.gameObject.SetActive(true);

        if (endScreen != null)
            endScreen.Show(false, false);

        if (chaosSystem != null)
            chaosSystem.InitializeChaos();
    }

    public void EndGame(bool win)
    {
        if (gameEnded) return;
        gameEnded = true;
        gameActive = false;

        Debug.Log(" Game Over — " + (win ? "You Win!" : "You Were Caught!"));

        // Freeze gameplay instantly
        DisablePlayerInput();
        Time.timeScale = 0f;

        // Unlock cursor for UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Hide HUD + Show End Screen
        if (hud != null)
            hud.gameObject.SetActive(false);

        if (endScreen != null)
            endScreen.Show(true, win);
    }

    public void RestartGame()
    {
        Debug.Log(" Restarting game...");
        Time.timeScale = 1f;
        gameActive = true;
        gameEnded = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DisablePlayerInput()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var thirdPerson = player.GetComponent<StarterAssets.ThirdPersonController>();
            if (thirdPerson != null)
                thirdPerson.enabled = false;

            var input = player.GetComponent<PlayerInput>();
            if (input != null)
                input.enabled = false;
        }
    }
}
