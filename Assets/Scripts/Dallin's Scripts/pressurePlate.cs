using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    public GameObject door;

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("LeftPressurePlate") && !GameObject.Find("RightPressurePlate"))
        {
            Destroy(door);
        }
    }
}
