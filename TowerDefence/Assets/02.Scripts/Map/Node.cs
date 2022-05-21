using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float towerOffsetY;
    private Tower towerBuilt;
    private Renderer rend;
    private Color originColor;
    public Color buildAvailableColor;
    public Color buildNotAvailableColor;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if (TowerHandler.instance.isSelected)
        {
            TowerHandler.instance.transform.position = transform.position + Vector3.up * towerOffsetY;


            if (towerBuilt == null)
            {
                rend.material.color = buildAvailableColor;
            }
            else
            {
                rend.material.color = buildNotAvailableColor;
            }
            
        }
    }

    private void OnMouseExit()
    {
        TowerHandler.instance.SendFar();   
        rend.material.color = originColor;
    }
}
