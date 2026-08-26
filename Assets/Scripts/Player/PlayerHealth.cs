using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField, Min(1)] private int maximumHealth = 100;

    public int CurrentHealth { get; private set; }
    public bool IsDefeated => CurrentHealth <= 0;

    private void Awake()
    {
        CurrentHealth = maximumHealth;
    }

    public void TakeDamage(int amount)
    {
        if (IsDefeated || amount <= 0)
            return;

        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);

        if (IsDefeated)
            HandleDefeat();
    }

    private void HandleDefeat()
    {
        Debug.Log("The player has been defeated.", this);
    }
}
