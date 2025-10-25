using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [Header("HUD References")]
    public TextMeshProUGUI textChaos;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textItems; // will now display active powerups
    public Image powerupBar;

    [Header("Game Settings")]
    public int chaosGoal = 30; // You can adjust in Inspector

    private float powerupTimer;
    private string activePowerupName = "";

    void Start()
    {
        if (powerupBar != null)
            powerupBar.fillAmount = 0;

        if (textChaos != null)
            textChaos.text = $"Chaos: 0 / {chaosGoal}";

        if (textItems != null)
            textItems.text = "Active: None";
    }

    // 🐾 Update chaos score on HUD
    public void UpdateChaos(int currentChaos)
    {
        if (textChaos != null)
            textChaos.text = $"Chaos: {currentChaos} / {chaosGoal}";
    }

    // 🕒 Update timer
    public void UpdateTimer(float timeRemaining)
    {
        if (textTime != null)
            textTime.text = $"Time: {Mathf.Ceil(timeRemaining)}s";
    }

    // 🌿 Update active powerups list
    public void UpdateActivePowerup(string powerupName)
    {
        activePowerupName = powerupName;
        if (textItems != null)
            textItems.text = $"Active: {powerupName}";
    }

    public void ClearActivePowerup()
    {
        activePowerupName = "";
        if (textItems != null)
            textItems.text = "Active: None";
    }

    // 💫 Powerup bar functions
    public void SetPowerup(float duration)
    {
        powerupTimer = duration;
        if (powerupBar != null)
            powerupBar.fillAmount = 1f;
    }

    public void UpdatePowerup(float normalizedTime)
    {
        if (powerupBar != null)
            powerupBar.fillAmount = normalizedTime;
    }

    public void HidePowerup()
    {
        if (powerupBar != null)
            powerupBar.fillAmount = 0f;
    }
}
