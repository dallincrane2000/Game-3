using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDoor : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnimate;
    // Update is called once per frame

    void Start()
    {
       doorAnimate = this.GetComponent<Animator>();
    }
    void Update()
    {
        if(GameObject.FindWithTag("Enemy") == false)
        {
            doorAnimate.SetFloat("Open", 1.0f);
            Destroy(door.GetComponent<Collider2D>());
        }
    }

}
