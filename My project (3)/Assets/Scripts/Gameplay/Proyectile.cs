using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float lifeTime = 2.0f;
    AudioSource source;
    float lifeTimer;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
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
            source.Play();
            Destroy(gameObject,source.clip.length);
        }
    }
}
