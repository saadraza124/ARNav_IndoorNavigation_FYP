using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
   
    public static void CreateMapScene()
    {
        SceneManager.LoadScene("CreateMap");
    }
    public static void SearchMapScene()
    {
       SceneManager.LoadScene("SearchMap");
    }
    public static void HomepageScene()
    {
        SceneManager.LoadScene("Homepage");
    }
    public void clear()
    {
        data.clearData();
    }

}
