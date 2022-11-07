using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    public GameObject player;
    public Transform exitPortalSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
        Instantiate(player, exitPortalSpawn.position, Quaternion.identity);
    }
}
