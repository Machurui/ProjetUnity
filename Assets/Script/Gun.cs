using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Reférences")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;

    float timeSinceLastShot;

    [Header("Audio")]
    public AudioSource reloadSound;
    public AudioSource shootSound;
    public AudioSource emptyMagazine;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }

    public void StartReload()
    {
        if (!gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;

        reloadSound.Play();

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                Debug.Log(muzzle);
                if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {

                    if (hitInfo.transform.tag == "Enemy")
                        Destroy(GameObject.Find(hitInfo.transform.name));
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                shootSound.Play();
            }
        }
        else
        {
            emptyMagazine.Play();
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(muzzle.position, muzzle.forward);
    }
}
