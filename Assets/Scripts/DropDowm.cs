using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropDowm : MonoBehaviour
{
    Dropdown menu;
    public GameObject pointer;
    public GameObject trailprefab;
    string[] locations;
    // Start is called before the first frame update
    void Start()
    {
        locations = data.readLocationsName();
         menu = transform.GetComponent<Dropdown>();
        menu.options.Clear();
        PopulateDropdown(menu, locations);

        // menu.options.Add(new Dropdown.OptionData() { text = "saad" });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PopulateDropdown(Dropdown dropdown, string[] optionsArray)
    {
        List<string> options = new List<string>();
        foreach (var option in optionsArray)
        {
            options.Add(option); // Or whatever you want for a label
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    public void onvaluechange()
    {
        if (searching.stillSearching == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("trail"));
            Destroy(GameObject.FindGameObjectWithTag("pointer"));
        }
            //Debug.Log(menu.options[menu.value].text);
            Vector3 cord = data.getLocationCoord(menu.options[menu.value].text);
            List<Vector3> drops = data.getDropsCoordinates(menu.options[menu.value].text);
            Instantiate(pointer, cord, Quaternion.identity);
            //searching a = new searching(drops,cord);
            Instantiate(trailprefab, Camera.main.transform.position, Quaternion.identity).GetComponent<searching>().initialize(drops, cord);
        searching.stillSearching = true;
      
        
    }
   
}
