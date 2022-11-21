using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed = 20;
    private Transform player;
    private Vector2 target;
    //public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        //animator.SetFloat("Move", 1);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Flying Enemy"))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        }
        if(hitInfo.CompareTag("Ground"))
        {
           Destroy(gameObject);
        }
        if(hitInfo.CompareTag("BulletPlayer"))
        {
           Destroy(gameObject);
        }
    }
    
}
