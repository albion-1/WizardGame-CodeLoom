using UnityEngine;

[CreateAssetMenu(
    fileName = "NewEnemy",
    menuName = "Wizard Game/Enemy Information")]
public class EnemyInformation : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] private string enemyName = "New Enemy";
    [SerializeField, TextArea] private string description;

    [Header("Combat")]
    [SerializeField, Min(1)] private int maximumHealth = 50;
    [SerializeField, Min(0)] private int attackDamage = 10;
    [SerializeField, Min(0f)] private float attackRange = 1.75f;
    [SerializeField, Min(0f)] private float attackCooldown = 1.25f;

    [Header("Movement")]
    [SerializeField, Min(0f)] private float movementSpeed = 3.5f;
    [SerializeField, Min(0f)] private float chaseRange = 12f;

    [Header("Rewards")]
    [SerializeField, Min(0)] private int experienceReward = 10;

    public string EnemyName => enemyName;
    public string Description => description;
    public int MaximumHealth => maximumHealth;
    public int AttackDamage => attackDamage;
    public float AttackRange => attackRange;
    public float AttackCooldown => attackCooldown;
    public float MovementSpeed => movementSpeed;
    public float ChaseRange => chaseRange;
    public int ExperienceReward => experienceReward;
}
