using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class data
{
    const string datafile = "/gps_data.csv";
  
    // Update is called once per frame
   
        
    static string getPath()
    {
        return Application.persistentDataPath+ datafile;
    }
    public static void writeData()
    {
         map_pointer obj = GameObject.FindGameObjectWithTag("pointer").GetComponent<map_pointer>();

        string filePath = getPath();
            StreamWriter writer = new StreamWriter(filePath,true);
        writer.Write(obj.Name + "," + obj.loc.x + "," + obj.loc.y + "," + obj.loc.z);
        writer.WriteLine();
        for (int i = 0; i < obj.drops.Count; i++)
            {
            writer.Write(obj.Name + ","+obj.drops[i].loc.x + "," + obj.drops[i].loc.y + "," + obj.drops[i].loc.z);
            writer.WriteLine();             
           }
             
            writer.Flush();
            writer.Close();
     }
    public static String[] readLocationsName()
    {
        string[] values;
        Stack<string> temp = new Stack<string>();
        string filePath = getPath();
        StreamReader reader = null;
        reader = File.OpenText(getPath());
        string z = reader.ReadLine();
        values = z.Split(',');
        temp.Push(values[0]);
        while (z != null)
        {
                    
            if ((temp.Peek() != values[0])&&(z!=null))
                {
                values = z.Split(',');
                temp.Push(values[0]);             
            }
            z = reader.ReadLine();
            if (z!=null)
            {
                values = z.Split(',');
            }          
        }
        reader.Close();
        String[] q = temp.ToArray();           
        return q;
    }
    public static void printarray(String[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Debug.Log(array[i]);
        }
    }
    public static void clearData()
    {
        string filePath = getPath();
        File.Create(filePath);
    }
   
     public static Vector3 getLocationCoord(String name)
    {
        Vector3 coord = new Vector3(0f,0f,0f);
        string[] values;
        string filePath = getPath();
        StreamReader reader = null;
        reader = File.OpenText(getPath());
        String z= reader.ReadLine();
        while ((z!=null))
        {
            values = z.Split(',');
            if (values[0] == name)
            {
                coord = assigncoord(float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]));               
                reader.Close();
                break;
            }
            z = reader.ReadLine();
            
        } 
        reader.Close();      
        return coord;
    }

    public static Vector3  assigncoord(float a, float b,float c)
    {
        return new Vector3(a,b,c);
    }
    public static List<Vector3> getDropsCoordinates(String name)
    {
        List<Vector3> coords = new List<Vector3>();

        string[] values;
        string filePath = getPath();
        StreamReader reader = null;
        reader = File.OpenText(getPath());
        String z = reader.ReadLine();
        while ((z != null))
        {
            values = z.Split(',');
            if (values[0] == name)
            {
                z = reader.ReadLine();
                values = z.Split(',');
                while (values[0] == name&&(z!=null))
                {
                    Vector3 temp = assigncoord(float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]));
                    coords.Add(temp);
                    z = reader.ReadLine();
                    if (z == null) { break; }
                    values = z.Split(',');
                }
            }
            z = reader.ReadLine();
        }
        reader.Close();

            return coords;
    }

}



