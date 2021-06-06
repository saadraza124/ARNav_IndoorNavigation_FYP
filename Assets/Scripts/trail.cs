using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour
{
    Vector3 curpos;
    Vector3 tarpos;
    public float step = 1;
    // Start is called before the first frame update
    void Start()
    {
        curpos = transform.position;
        tarpos = new Vector3(0f,-0.5f,4f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position,tarpos,step*Time.deltaTime);
        if (transform.position == tarpos)
        {
            tarpos = new Vector3(1f,-0.5f,5f);
            if (transform.position == tarpos)
            {
                transform.position = curpos;
                tarpos = new Vector3(0f, -0.5f, 4f);
            }
        }
    }
}
