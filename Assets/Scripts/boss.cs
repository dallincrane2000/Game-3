using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    public float health = 10.0f;
    private float count;
    public GameObject orb;
    
    public AudioSource EnemyDeath;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            takeDamage(1.0f);
        }
    }
    
    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if(!GameObject.Find("Smaller Overlord(Clone)"))
            {
                Instantiate(orb, this.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            EnemyDeath.Play();
        }
    }
}
