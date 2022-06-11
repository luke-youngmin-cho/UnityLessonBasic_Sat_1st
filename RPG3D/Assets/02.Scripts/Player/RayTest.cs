using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position,
                                    Vector3.down,
                                    out RaycastHit hit,
                                    100.0f
                                    ))
        {
            Debug.DrawRay(transform.position, Vector3.down * 100.0f, Color.red);
        }
        else
            Debug.DrawRay(transform.position, Vector3.down * 100.0f, Color.green);
    }
}
