using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class map_pointer : MonoBehaviour
{
      public string Name;
    public Vector3 loc;
    public List<drop_point> drops = new List<drop_point>();

    // Start is called before the first frame update
    void Start()
    {
        get_loc();
    }

    // Update is called once per frame
    void Update()
    {
        rotate();// pointer rotation
    }
    void rotate()
    {
        gameObject.transform.Rotate(Vector3.up * 200 * Time.deltaTime);
    }
    void get_loc()
    {
        loc = transform.position;

    }
}
