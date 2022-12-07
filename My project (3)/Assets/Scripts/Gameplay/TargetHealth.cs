using System;
using UnityEngine;

public class TargetHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float pointsWorth = 20;

    bool dead;
    public static Action onTargetSpawn;
    public static Action<float> onTargetDestroy;
    private void Start()
    {
        onTargetSpawn?.Invoke();
    }
    public void TakeDamage(int damage)
    {
        if (!dead)
        {
            onTargetDestroy?.Invoke(pointsWorth);
        }
        dead = true;
        Destroy(gameObject);
    }
}
