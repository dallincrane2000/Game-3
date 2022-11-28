using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    private Transform target;
    public Rigidbody2D rb;
    private GameObject enemyParent;
    public float moveSpeed = 5f;
    public GameObject bullet;
    public Transform firePoint;
    private float timeBetweenShots;
    public float startTimeBtwShots;
    private Vector2 movement;
    private float step;
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
            Vector3 direction = target.position - enemyParent.transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)enemyParent.transform.position + (direction * moveSpeed * Time.deltaTime));
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
