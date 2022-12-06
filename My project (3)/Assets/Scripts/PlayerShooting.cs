using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float shotForce;
    [SerializeField] float reloadTime;
    [SerializeField] Transform barrelMuzzle;
    [SerializeField] bool canShoot = true;

    float reloadTimer;
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load("Bullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            GameObject go = Instantiate(bullet,barrelMuzzle.position,Quaternion.identity,null);
            Rigidbody bulletRb;
            if(go.TryGetComponent(out bulletRb))
            {
                bulletRb.AddForce(transform.forward * shotForce, ForceMode.Impulse);
            }
            canShoot = false;
        }
        else
        {
            reloadTimer += Time.deltaTime;
            if(reloadTimer >= reloadTime)
            {
                canShoot = true;
                reloadTimer = 0.0f;
            }
        }
    }
}
