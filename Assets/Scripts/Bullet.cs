using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float damage = 1.0f;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject player;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        animator.SetFloat("Move", 1);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Player"))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        }
        if(hitInfo.CompareTag("Player"))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), enemy.GetComponent<Collider>());
        }
        //Enemy enemy = hitInfo.GetComponent<Enemy>();
        //if(enemy != null)
        //{
       //     enemy.takeDamage(damage);
        //}
        Destroy(gameObject);
    }
}
