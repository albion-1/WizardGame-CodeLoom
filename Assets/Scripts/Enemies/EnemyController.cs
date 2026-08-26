using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyInformation information;
    [SerializeField] private Transform target;

    private NavMeshAgent agent;
    private PlayerHealth targetHealth;
    private float nextAttackTime;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
                target = player.transform;
        }

        if (target != null)
            targetHealth = target.GetComponent<PlayerHealth>();

        if (information == null)
        {
            Debug.LogError("Enemy information is missing.", this);
            enabled = false;
            return;
        }

        agent.speed = information.MovementSpeed;
        agent.stoppingDistance = information.AttackRange;
    }

    private void Update()
    {
        if (target == null || targetHealth == null || targetHealth.IsDefeated)
        {
            agent.ResetPath();
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > information.ChaseRange)
        {
            agent.ResetPath();
            return;
        }

        if (distance > information.AttackRange)
        {
            agent.SetDestination(target.position);
            return;
        }

        agent.ResetPath();
        Attack();
    }

    private void Attack()
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + information.AttackCooldown;
        targetHealth.TakeDamage(information.AttackDamage);
    }
}
