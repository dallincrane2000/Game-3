using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    private Transform target;
    private GameObject enemyParent;
    public float speed = 3f;
    public GameObject bullet;
    public Transform firePoint;
    private float timeBetweenShots;
    public float startTimeBtwShots;
    // Update is called once per frame

    void Start()
    {
        enemyParent = this.transform.parent.gameObject;
        timeBetweenShots = startTimeBtwShots;
    }
    void Update()
    {   
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            enemyParent.transform.position = Vector2.MoveTowards(enemyParent.transform.position, target.position, step);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;

            if(timeBetweenShots <= 0)
            {
                Instantiate(bullet, firePoint.position, Quaternion.identity);
                timeBetweenShots = startTimeBtwShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = null;
            //Destroy(bullet)
        }
    }
}
