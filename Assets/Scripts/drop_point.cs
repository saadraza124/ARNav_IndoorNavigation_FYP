using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_point : MonoBehaviour
{
    public Vector3 loc;
    // Start is called before the first frame update
    void Start()
    {
        get_loc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void get_loc()
    {
        loc = transform.position;

    }

    
}
