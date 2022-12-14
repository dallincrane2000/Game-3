using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float offset;
    private Transform initialposition;

    public AudioSource ArrowSound;

    void Start()
    {   
        //bulletPrefab = GameObject.Find("Bullet(Clone)");
        //initialposition.position = this.transform.position;
    }

    void Update()
    {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            
            if(Input.GetMouseButtonDown(0))
            {
            ArrowSound.Play();
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                //float dist = Vector3.Distance(initialposition.position, bulletPrefab.transform.position);
                //if(dist >= 3)
                //{
                //   Destroy(bulletPrefab);
                //}
            }
    }
}
