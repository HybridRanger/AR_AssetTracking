using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotator : MonoBehaviour {

    private int x, y, z, w;
    private int vx, vy, vz;
    public float Vx, Vy, Vz;
    public Text outputText;
    private Gyroscope gyro;
    public InputField[] Qvalues;
    public InputField[] Vvalues;

    void Start()
    {
        //set up and enable device gyro
        if (Application.platform == RuntimePlatform.Android)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void Update()
    {
        Quaternion quat;

        //get gyro data
        if (Application.platform == RuntimePlatform.Android)
        {
            quat = gyro.attitude;
        }
        else
        {
            quat = Quaternion.Euler(Vx, Vy, Vz);
        }

        outputText.text = "Gyroscope: " + quat + "Vector" + GyroToEuler(quat) + "\n" + quat.eulerAngles;

        //rotate camera with euler angles
        //Vector3 eul = GyroToEuler(quat);
        //transform.eulerAngles = eul;
        //quat.SetLookRotation(Vector3.forward, Vector3.up);
        //transform.rotation = quat;
        transform.eulerAngles = GyroToEuler(quat);
    }

    //format gyro attitude to unity euler angles
    private Vector3 GyroToEuler(Quaternion q)
    {
        float[] qA = new float[4];
        qA[0] = q.x;
        qA[1] = q.y;
        qA[2] = q.z;
        qA[3] = q.w;
        Vector3 v = new Quaternion(qA[x], qA[y], qA[z], qA[w]).eulerAngles;
        float[] vA = new float[3];
        vA[0] = v.x;
        vA[1] = v.y;
        vA[2] = v.z;
        return new Vector3(0, vA[vy], 0);
    }

    public void SetValues()
    {
        int.TryParse(Qvalues[0].text, out x);
        int.TryParse(Qvalues[1].text, out y);
        int.TryParse(Qvalues[2].text, out z);
        int.TryParse(Qvalues[3].text, out w);

        int.TryParse(Vvalues[0].text, out vx);
        int.TryParse(Vvalues[1].text, out vy);
        int.TryParse(Vvalues[2].text, out vz);
    }
}
