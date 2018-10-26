using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCameraAuth : MonoBehaviour {

    IEnumerator Start()
    {
        //ask user for camera authorisation if cameras detected
        if (FindWebCams())
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                Debug.Log("Webcam Found");
            }
            else
            {
                Debug.Log("Webcam Not Found");
            }
        }
    }

    //list all connected cameras
    bool FindWebCams()
    {
        Debug.Log("Connected Cameras: ");
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            foreach (WebCamDevice device in devices)
            {
                Debug.Log("Name: " + device);
            }
            return true;
        }
        else
        {
            Debug.Log("No Cameras Found");
            return false;
        }
    }
}
