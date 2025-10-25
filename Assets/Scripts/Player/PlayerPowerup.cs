using UnityEngine;
using System.Collections;

public class PlayerPowerup : MonoBehaviour
{
    [Header("References")]
    public HUDController hud; // Drag your HUD Canvas here

    [Header("Powerup Settings")]
    public float speedMultiplier = 1.3f;   // Slightly lower boost for balance
    public float duration = 6f;            // How long each catnip lasts

    private StarterAssets.ThirdPersonController controller;
    private float baseMoveSpeed;
    private float baseSprintSpeed;

    private float activeTimer = 0f;
    private int activeStacks = 0;
    private bool boosting = false;

    void Start()
    {
        controller = GetComponent<StarterAssets.ThirdPersonController>();
        baseMoveSpeed = controller.MoveSpeed;
        baseSprintSpeed = controller.SprintSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Powerup"))
        {
            Debug.Log($"🍃 Picked up Catnip at {Time.time:F1}s!");
            Destroy(other.gameObject);

            activeStacks++;
            activeTimer += duration;

            Debug.Log($"🌟 Boost stacks = {activeStacks}, timer extended to {activeTimer:F1}s");

            hud?.UpdateActivePowerup("Catnip Boost");

            if (!boosting)
                StartCoroutine(BoostRoutine());
        }
    }

    private IEnumerator BoostRoutine()
    {
        boosting = true;
        hud?.SetPowerup(activeTimer);

        while (activeTimer > 0)
        {
            float stackBoost = 1f + (activeStacks * (speedMultiplier - 1f));
            controller.MoveSpeed = baseMoveSpeed * stackBoost;
            controller.SprintSpeed = baseSprintSpeed * stackBoost;

            activeTimer -= Time.deltaTime;
            hud?.UpdatePowerup(activeTimer / duration);

            yield return null;
        }

        // Reset
        controller.MoveSpeed = baseMoveSpeed;
        controller.SprintSpeed = baseSprintSpeed;
        activeStacks = 0;
        boosting = false;
        hud?.HidePowerup();
        hud?.ClearActivePowerup();

        Debug.Log("💤 Powerup expired — speeds reset to normal.");
    }
}
