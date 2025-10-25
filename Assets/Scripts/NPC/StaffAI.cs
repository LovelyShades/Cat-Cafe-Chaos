using UnityEngine;
using UnityEngine.AI;

public class StaffAI : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    private NavMeshAgent agent;

    [Header("Behavior Settings")]
    public Transform[] patrolPoints;      // assign in Inspector
    public float patrolWait = 2f;         // seconds at each point
    public float chaseRange = 10f;        // starts chasing when player within this range
    public float catchDistance = 1.0f;    // distance to trigger "caught"
    public float patrolSpeed = 1.5f;
    public float chaseSpeed = 3.0f;

    private int currentPatrol = 0;
    private bool isChasing = false;
    private bool caught = false;
    private float waitTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player")?.transform;

        // Baseline agent setup
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.stoppingDistance = 0.2f;   // 🔹 ensures Staff gets close enough to collide
        agent.speed = patrolSpeed;

        if (patrolPoints != null && patrolPoints.Length > 0)
            agent.SetDestination(patrolPoints[currentPatrol].position);
    }

    void Update()
    {
        if (GameManager.Instance == null || !GameManager.Instance.gameActive || caught)
            return;

        float distToPlayer = Vector3.Distance(transform.position, player.position);

        // 🔹 Switch between patrol and chase
        if (distToPlayer < chaseRange)
        {
            isChasing = true;
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);
        }
        else
        {
            isChasing = false;
            Patrol();
        }

        // 🔹 Instant catch when close enough (works even at slow speed)
        if (distToPlayer <= catchDistance)
        {
            caught = true;
            Debug.Log("Caught the player!");
            GameManager.Instance.EndGame(false);
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        agent.speed = patrolSpeed;

        if (!agent.pathPending && agent.remainingDistance < 0.3f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= patrolWait)
            {
                currentPatrol = (currentPatrol + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[currentPatrol].position);
                waitTimer = 0f;
            }
        }
    }

    // 🔹 Optional backup trigger (if using a CatchZone collider)
    private void OnTriggerEnter(Collider other)
    {
        if (caught) return;
        if (other.CompareTag("Player"))
        {
            caught = true;
            Debug.Log("Caught player via trigger!");
            GameManager.Instance.EndGame(false);
        }
    }
}
