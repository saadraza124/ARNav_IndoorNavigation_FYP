using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public  class gps : MonoBehaviour
{
    public static float latitude;
    public static float longitude;
    public static float altitude;
    public static Text x;
    public static Text y;
    public static Text z;

    // Start is called before the first frame update
    void Awake()
    {
        x = GameObject.FindGameObjectWithTag("longitude_screen").GetComponent<Text>();
        y = GameObject.FindGameObjectWithTag("latitude_screen").GetComponent<Text>();
        z = GameObject.FindGameObjectWithTag("altitude_screen").GetComponent<Text>();
 
    }
    private void Start()
    {
        permission();
       // startgps();
    }
    private IEnumerator StartLocationService()
    {
        while (true)
        {


            if (Input.location.isEnabledByUser)
            {
                Input.location.Start();
            }

            while (Input.location.status == LocationServiceStatus.Initializing)
            {
                yield return new WaitForSeconds(1);
            }
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determine device location");
                yield break;
            }
            //Debug.Log("Latitude : " + Input.location.lastData.latitude);
           // Debug.Log("Longitude : " + Input.location.lastData.longitude);
           // Debug.Log("Altitude : " + Input.location.lastData.altitude);
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            altitude = Input.location.lastData.altitude;
            yield return null;
        }
    }

    // Update is called once per frame
   /* public void startgps()
    {
        StartCoroutine(StartLocationService());
        x.text = "Longitude: " + longitude;
        y.text = "Latitude: " + latitude;
        z.text = "Altitude: " + altitude;

    }*/
    public void permission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }
}
