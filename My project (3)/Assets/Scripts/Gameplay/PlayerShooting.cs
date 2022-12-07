using System.Collections;
using UnityEngine;

namespace TankGame
{

    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] float shotForce;
        [SerializeField] float reloadTime;
        [SerializeField] Transform barrelMuzzle;
        [SerializeField] bool canShoot = true;

        float reloadTimer;
        float turnTime = 0.2f;
        GameObject bullet;
        Camera mainCamera;
        AudioSource source;
        // Start is called before the first frame update
        void Start()
        {
            mainCamera = Camera.main;
            source = GetComponent<AudioSource>();
            bullet = Resources.Load("Bullet") as GameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (canShoot && Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Shoot());
                canShoot = false;
            }
            else
            {
                reloadTimer += Time.deltaTime;
                if (reloadTimer >= reloadTime)
                {
                    canShoot = true;
                    reloadTimer = 0.0f;
                }
            }
        }

        IEnumerator Shoot()
        {
            Ray screenRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(screenRay, out hit))
            {

                Vector3 targetVector = hit.point - transform.position;
                targetVector.y = 0f;
                Quaternion startRotation = transform.rotation;
                var finalRotation = Quaternion.LookRotation(targetVector);
                var t = 0f;
                while (t <= 1f)
                {
                    t += Time.deltaTime / turnTime;
                    transform.rotation = Quaternion.Lerp(startRotation, finalRotation, t);
                    yield return null;
                }
                transform.rotation = finalRotation;
                source.Play();
                Rigidbody bulletRb;
                GameObject go = Instantiate(bullet, barrelMuzzle.position, Quaternion.identity, null);
                if (go.TryGetComponent(out bulletRb))
                {
                    bulletRb.AddForce(transform.forward * shotForce, ForceMode.Impulse);
                }
            }
            yield return null;
        }
    }
}
