using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnimate;

    void Start()
    {
        Collider2D collider = door.GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("LeftPressurePlate") && !GameObject.Find("RightPressurePlate"))
        {
            doorAnimate.SetFloat("Open", 1.0f);
            Destroy(door.GetComponent<Collider2D>());
        }
    }
}
