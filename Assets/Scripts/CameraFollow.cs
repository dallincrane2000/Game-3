using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    private Transform target;
    public Transform player;
    protected float followSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("Player"))
        {
            target = GameObject.Find("Player(Clone)").transform;
            float xTarget = target.position.x + x;
            float yTarget = target.position.y + y;
            float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
            float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
            transform.position = new Vector3(xNew, yNew, transform.position.z);
        }
        else
        {
            target = GameObject.Find("Player").transform;
            float xTarget = target.position.x + x;
            float yTarget = target.position.y + y;
            float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
            float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
            transform.position = new Vector3(xNew, yNew, transform.position.z);
        }
    }
}
