using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    private Transform target;
    private GameObject enemyParent;
    public float speed = 3f;
    // Update is called once per frame

    void Start()
    {
        enemyParent = this.transform.parent.gameObject;
        //this.transform.parent = enemyParent;
    }
    void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            enemyParent.transform.position = Vector2.MoveTowards(enemyParent.transform.position, target.position, step);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}
