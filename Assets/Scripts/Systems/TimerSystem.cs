using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    public float totalTime = 60f;
    private float currentTime;
    public HUDController hud;

    void Start()
    {
        currentTime = totalTime;
        if (hud != null)
            hud.UpdateTimer(currentTime);
    }

    void Update()
    {
        if (GameManager.Instance == null || !GameManager.Instance.gameActive)
            return;

        currentTime -= Time.deltaTime;

        if (hud != null)
            hud.UpdateTimer(currentTime);

        if (currentTime <= 0)
            GameManager.Instance.EndGame(false);
    }
}
