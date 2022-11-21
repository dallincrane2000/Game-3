using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private float health = 10.0f;

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

    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
