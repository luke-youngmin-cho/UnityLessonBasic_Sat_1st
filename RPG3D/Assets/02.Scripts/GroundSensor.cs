using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isOn;
    [SerializeField] private LayerMask groundLayer;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("on ground");
        if (isOn == false &&
            1 << other.gameObject.layer == groundLayer)
        {
            isOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("deteached from ground");
        if (isOn &&
            1 << other.gameObject.layer == groundLayer)
        {
            isOn = false;
        }
    }
}
