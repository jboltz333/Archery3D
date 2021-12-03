using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // If an arrow hits a target, destroy the arrow
        if (collision.gameObject.tag == "Target")
        {
            Destroy(this.gameObject);
        }
    }
}
