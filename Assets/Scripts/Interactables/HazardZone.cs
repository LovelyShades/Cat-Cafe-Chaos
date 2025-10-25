using UnityEngine;
using System.Collections;

public class HazardZone : MonoBehaviour
{
    public float slowDuration = 2f;
    public float slowMultiplier = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger: " + other.name); // 🔹 TEST LINE
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<StarterAssets.ThirdPersonController>();
            if (player != null)
            {
                StartCoroutine(SlipEffect(player));
            }
        }
    }

    private IEnumerator SlipEffect(StarterAssets.ThirdPersonController player)
    {
        Debug.Log("Applying slowdown to player");
        float originalSpeed = player.MoveSpeed;
        float originalSprint = player.SprintSpeed;

        player.MoveSpeed *= slowMultiplier;
        player.SprintSpeed *= slowMultiplier;

        yield return new WaitForSeconds(slowDuration);

        player.MoveSpeed = originalSpeed;
        player.SprintSpeed = originalSprint;
        Debug.Log("Restored player speed");
    }
}
