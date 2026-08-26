using UnityEngine;

[CreateAssetMenu(
    fileName = "NewEnemy",
    menuName = "Wizard Game/Enemy Information")]
public class EnemyInformation : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] private string enemyName = "New Enemy";
    [SerializeField, TextArea] private string description;
    [SerializeField] private Sprite portrait;

    [Header("Stats")]
    [SerializeField, Min(1f)] private float maximumHealth = 100f;
    [SerializeField, Min(0f)] private float damage = 10f;
    [SerializeField, Min(0f)] private float movementSpeed = 3f;
    [SerializeField, Min(0f)] private float attackRange = 2f;
    [SerializeField, Min(0f)] private float attackCooldown = 1f;

    [Header("Rewards")]
    [SerializeField, Min(0)] private int experienceReward = 10;

    public string EnemyName => enemyName;
    public string Description => description;
    public Sprite Portrait => portrait;
    public float MaximumHealth => maximumHealth;
    public float Damage => damage;
    public float MovementSpeed => movementSpeed;
    public float AttackRange => attackRange;
    public float AttackCooldown => attackCooldown;
    public int ExperienceReward => experienceReward;
}
