using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

  public class initialize : MonoBehaviour
{
    [SerializeField] GameObject Back_button;
    [SerializeField] GameObject Save_button;
    [SerializeField] GameObject Pointer_name_input;
    [SerializeField] GameObject Place_pointer_button;
    [SerializeField] GameObject Place_droppoint_button;
    [SerializeField] GameObject Save_map_button;
    private void Awake()
    {
        UI.back_button = Back_button;
        UI.save_button = Save_button;
        UI.pointer_name_input = Pointer_name_input;
        UI.place_pointer_button = Place_pointer_button;
        UI.place_droppoint_button = Place_droppoint_button;
        UI.save_map_button = Save_map_button;
    }
    // Start is called before the first frame update
    void Start()
    {
        UI.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
