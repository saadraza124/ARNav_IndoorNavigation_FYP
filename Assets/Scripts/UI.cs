using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class UI 
{
    public static GameObject back_button;
   public static  GameObject save_button;
    public static  GameObject pointer_name_input;
    public static  GameObject place_pointer_button;
    public static GameObject place_droppoint_button;
    public static GameObject save_map_button;
        public static void Start()
    {

        save_button.gameObject.SetActive(false);
        back_button.gameObject.SetActive(false);
        pointer_name_input.gameObject.SetActive(false);
        place_droppoint_button.gameObject.SetActive(false);
        save_map_button.gameObject.SetActive(false);
    }

    public static void placepointerbutton()
    {
        place_pointer_button.gameObject.SetActive(false);
        pointer_name_input.gameObject.SetActive(true);
        save_button.gameObject.SetActive(true);      
        
    }
    public static void savebutton()
    {
        save_button.gameObject.SetActive(false);
        pointer_name_input.gameObject.SetActive(false);
        place_droppoint_button.gameObject.SetActive(true);
        save_map_button.gameObject.SetActive(true);
    }
    public static void savemapbutton()
    {
        place_droppoint_button.gameObject.SetActive(false);
        save_map_button.gameObject.SetActive(false);
    }
}
