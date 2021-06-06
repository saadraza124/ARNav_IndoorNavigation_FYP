using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class searching : MonoBehaviour
{
    public static bool stillSearching = false;
    public  List<Vector3> drops;
    public Vector3 destination;
    Vector3 curpos;
    public float speed;
    int count = 0;
    int temp;
    Vector3 targetpos;
     public void  initialize(List<Vector3> d, Vector3 dest)
    {
        this.drops = d;
        this.destination = dest;
        
        
    }
    public void Start()
    {
        curpos = Camera.main.transform.position;
        count = drops.Count - 1;
        temp = count;
        targetpos = drops[count];
        Debug.Log(count);
    }
    public void Update()
    {
        
        speed = 3;
        
        transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
        if (transform.position == drops[count])
         {

             count--;
            
             if (count == 0)
             {
                targetpos = destination;
                 count = temp;
             }
            else { targetpos = drops[count]; }
            
            
        }else  if (transform.position == destination)
            {
                transform.position = curpos;
                Debug.Log("dest");
                targetpos = drops[count];
            }
    }
   
    

    
   
}
