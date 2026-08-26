using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyInformation information;

    public int CurrentHealth { get; private set; }
    public bool IsDefeated => CurrentHealth <= 0;

    private void Awake()
    {
        if (information == null)
        {
            Debug.LogError("Enemy information is missing.", this);
            enabled = false;
            return;
        }

        CurrentHealth = information.MaximumHealth;
    }

    public void TakeDamage(int amount)
    {
        if (!enabled || IsDefeated || amount <= 0)
            return;

        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);

        if (IsDefeated)
            Destroy(gameObject);
    }
}
