using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectSoul : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
<<<<<<< Updated upstream
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
=======
>>>>>>> Stashed changes
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
