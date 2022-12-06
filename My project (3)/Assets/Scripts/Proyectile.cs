using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float lifeTime = 2.0f;

    float lifeTimer;
    private void Update()
    {
        if(lifeTimer< lifeTime)
        {
            lifeTimer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable;
        if(collision.collider.TryGetComponent(out damageable))
        {
            damageable.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
