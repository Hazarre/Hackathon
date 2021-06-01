using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab; 

    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonDown("Fire1")) if (this.GetComponent<PlayerStats>().numBullet > 0) Shoot();
    }

    void Shoot()
    {
        //Shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        this.GetComponent<PlayerStats>().numBullet--;


    }
}
