using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GPSManager : MonoBehaviour {
    
	public Button button;

    IEnumerator Start()
    {
		Debug.Log (Input.location.isEnabledByUser);
		Debug.Log (Input.location.status);
		//button.interactable = false;
		// First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
			yield break;

        // Start service before querying location
		Input.location.Start(1,1);
        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
			
			yield return new WaitForSeconds(1);

            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            //theText.text = "Timed out";
			Debug.Log("time out");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            //theText.text = "Unable to determine device location";
			Debug.Log("fail");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
			Debug.Log("correct");
            checkGPS();
        }



    }

    // Update is called once per frame
    void Update () {
        checkGPS();
    }
    void checkGPS() {
        double lat = Input.location.lastData.latitude;
        double len = Input.location.lastData.longitude;
		//double LTlat = 1.345211;  1.346584, 103.679718
        //double LTlong = 103.681185;
		double LTlat =  1.346584;
		double LTlong = 103.679718;
        double dist = DistanceBetweenPlaces(lat, len, LTlat, LTlong);

        
        if (dist <= 100)
        {
			//button.interactable = true;
        }
        else {
			//button.interactable = false;
        }
    }
    public static double Radians(double x)
    {
        return x * Math.PI / 180;
    }
    public static double DistanceBetweenPlaces(double lon1, double lat1, double lon2, double lat2)
    {
        double R = 6371000; // metres

        double sLat1 = Math.Sin(Radians(lat1));
        double sLat2 = Math.Sin(Radians(lat2));
        double cLat1 = Math.Cos(Radians(lat1));
        double cLat2 = Math.Cos(Radians(lat2));
        double cLon = Math.Cos(Radians(lon1) - Radians(lon2));

        double cosD = sLat1 * sLat2 + cLat1 * cLat2 * cLon;

        double d = Math.Acos(cosD);

        double dist = R * d;

        return dist;
    }
}
