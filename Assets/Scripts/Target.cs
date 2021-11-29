using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void Start()
    {
        // Spawn the target in a random place on our map, with the target at a random angle
        transform.position = new Vector3(Random.Range(-21.5f, 22.5f), Random.Range(1.5f, 3.5f), Random.Range(-17.5f, 21.5f));
        transform.rotation = Quaternion.Euler(90.0f, Random.Range(0.0f, 360.0f), 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check whether the target was hit by an arrow
        if (collision.gameObject.tag == "Arrow")
        {
            // Play a hit sound
            // decrease number of targets left showed to user
            // destroy
        }
    }
}
