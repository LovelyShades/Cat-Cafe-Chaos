using UnityEngine;

public class ChaosSystem : MonoBehaviour
{
    [Header("Chaos Settings")]
    public int currentChaos = 0;
    public int maxChaos = 30;

    [Header("References")]
    public HUDController hud;

    void Start()
    {
        // Safety fallback in case GameManager didn't call InitializeChaos
        if (hud == null && GameManager.Instance != null)
            hud = GameManager.Instance.hud;

        InitializeChaos();
    }

    //  Called by GameManager.Start()
    public void InitializeChaos()
    {
        currentChaos = 0;
        hud?.UpdateChaos(currentChaos);
    }

    //  Add chaos when knocking objects
    public void AddChaos(int amount)
    {
        if (GameManager.Instance == null || !GameManager.Instance.gameActive)
            return;

        currentChaos += amount;
        currentChaos = Mathf.Clamp(currentChaos, 0, maxChaos);

        Debug.Log($" Chaos increased to {currentChaos}/{maxChaos}");
        hud?.UpdateChaos(currentChaos);

        if (currentChaos >= maxChaos)
        {
            Debug.Log(" CHAOS GOAL REACHED — Player wins!");
            GameManager.Instance.EndGame(true);
        }
    }
}
