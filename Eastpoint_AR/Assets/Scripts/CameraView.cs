using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour { 
    

	public void StartCamera () {

        //start webcam if user has provided authorisation
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamTexture webCamView = new WebCamTexture();
            Renderer planeRenderer = GetComponent<Renderer>();

            //set plane material to camera view
            planeRenderer.material.mainTexture = webCamView;
            webCamView.Play();

            Debug.Log("Webcam Started");
        }
        else
        {
            Debug.Log("Unable to start webcam - no User Authorisation");
        }
	}

    void Start()
    {
        Camera cam = Camera.main;

        float pos = (cam.nearClipPlane + 100.0f);

        transform.position = cam.transform.position + cam.transform.forward * pos;
        transform.LookAt(cam.transform);
        transform.Rotate(90.0f, 0.0f, 0.0f);

        float h = (Mathf.Tan(cam.fieldOfView * Mathf.Deg2Rad * 0.5f) * pos * 2f) / 10.0f;

        transform.localScale = new Vector3(h * cam.aspect, 1.0f, h);
    }
}
