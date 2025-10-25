using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KnockableObject : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Chaos Settings")]
    public int chaosValue = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Only count chaos if it hits the floor layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            // Check if the impact was hard enough to be noticeable
            if (collision.relativeVelocity.magnitude > 0.8f)
            {
                Debug.Log($" {gameObject.name} hit the floor hard! Chaos +{chaosValue}");
                GameManager.Instance.GetComponent<ChaosSystem>()?.AddChaos(chaosValue);
            }
        }
    }
}
