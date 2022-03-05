using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    [HideInInspector] public int a;
    [SerializeField] private float b;

    
    private void Awake()
    {
        a = 1;
        b = 1.0f;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
