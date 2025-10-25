using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PushRigidbody : MonoBehaviour
{
    public float pushPower = 2.5f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody or is kinematic → ignore
        if (body == null || body.isKinematic)
            return;

        // ignore tiny downward pushes
        if (hit.moveDirection.y < -0.3f)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.AddForce(pushDir * pushPower, ForceMode.Impulse);
    }
}
