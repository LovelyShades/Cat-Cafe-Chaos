using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScreenController : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI statsText;
    public Button restartButton;

    private void Start()
    {
        if (restartButton != null)
            restartButton.onClick.AddListener(OnRestartButton);
    }

    public void Show(bool show, bool win)
    {
        gameObject.SetActive(show);

        if (show)
        {
            if (resultText != null)
                resultText.text = win ? "You Won!" : "Caught!";

            if (statsText != null)
                statsText.text = win ? "You caused maximum chaos!" : "Try again, kitty!";
        }
    }

    private void OnRestartButton()
    {
        Debug.Log("Restart button clicked!");
        FindObjectOfType<GameManager>()?.RestartGame();
    }
}
