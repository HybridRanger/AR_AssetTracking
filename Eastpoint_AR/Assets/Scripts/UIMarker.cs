using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMarker : MonoBehaviour {

    public Camera cam;
    public Text outputText;
    public GameObject Target;
    public float min = 0.2f, max = 0.8f;
    public float val = 10;
    public GameObject pointer, cameraObject;

    void Start()
    {
        //cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 targetPos = Target.transform.position;
        Vector3 viewportPos = cam.WorldToViewportPoint(targetPos);

        

        Vector3 screenPos = cam.ViewportToScreenPoint(viewportPos);

        float camAngle = (cameraObject.transform.rotation.y * Mathf.Rad2Deg) - 90;

        float targetAngle = pointer.transform.rotation.y * Mathf.Rad2Deg;
        float difference = (targetAngle - camAngle) ;

        if (difference < -10)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 270);
            GetComponent<RectTransform>().position = cam.ViewportToScreenPoint(new Vector3(min, 0.5f, 0.0f));

        }
        else if (difference > 10)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 90);
            GetComponent<RectTransform>().position = cam.ViewportToScreenPoint(new Vector3(max, 0.5f, 0.0f));
        }
        else
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            GetComponent<RectTransform>().position = screenPos + new Vector3(0, val, 0);
        }

        //outputText.text = "target: " + targetPos + "\n\nviewport: " + viewportPos + "\nscreen: " + screenPos + "\n\ncam: " + camAngle + "\npointer" + targetAngle + "\ndifference" + difference;
    }

    bool CheckIfOffScreen(Vector3 vp)
    {
        if (vp.x < min || vp.x > max || vp.y < min || vp.y > max)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

}
