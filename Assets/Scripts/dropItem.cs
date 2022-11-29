using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItem : MonoBehaviour
{
    public GameObject orb;
    private Transform epos;

    void Start()
    {
        epos = GetComponent<Transform>();
    }

    public void DropItem()
    {
        Instantiate(orb, epos.position, Quaternion.identity);
    }
}
