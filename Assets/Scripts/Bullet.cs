using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float damage = 10f;
    public Rigidbody2D rb;
    //public Animator animator;
    public GameObject player;
    private GameObject parentObj;
    private GameObject childObject;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        //animator.SetFloat("Move", 1);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(gameObject)
        {
            if(hitInfo.CompareTag("Player"))
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            }
            
            Destroy(gameObject);

            enemy enemy1 = hitInfo.GetComponentInChildren<enemy>();
            Overlord overlord1 = hitInfo.GetComponentInChildren<Overlord>();
            if(enemy1 != null)
            {
            enemy1.takeDamage(damage);
            } else if(overlord1 != null)
            {
                overlord1.takeDamage(damage);
            }
        }  
    }
}
