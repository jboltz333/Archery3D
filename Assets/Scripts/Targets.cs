using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        SpawnTargets();
    }

    private void SpawnTargets()
    {
        for (int i = 0; i < 20; i++)
        {
            // Spawn a target object
            GameObject targetObject = Instantiate(target);

            // Spawn the target in a random place on our map
            targetObject.transform.position = new Vector3(Random.Range(-21.5f, 22.5f), Random.Range(1.5f, 3.5f), Random.Range(-17.5f, 21.5f));
            targetObject.transform.rotation = Quaternion.Euler(90.0f, Random.Range(0.0f, 360.0f), 0.0f);
        }
    }
}
