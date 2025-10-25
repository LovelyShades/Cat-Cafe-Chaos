using UnityEngine;

public class CatchZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Caught Player via CatchZone!");
            FindObjectOfType<GameManager>()?.EndGame(false);
        }
    }
}
