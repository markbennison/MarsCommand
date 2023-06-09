using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DisplayWebCam : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.RawImage rawImage0, rawImage1, duplicateRawImage0, duplicateRawImage1;

    int kandaoMeetingIndex = 0;
    int OBSVirtualCameraIndex = 0;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
            if (devices[i].name == "Kandao Meeting")
            {
                kandaoMeetingIndex = i;
            }
            if (devices[i].name == "OBS Virtual Camera")
            {
                OBSVirtualCameraIndex = i;
                Debug.Log("FOUND OBS " + i);
            }
        }

        //Renderer rend = this.GetComponentInChildren<Renderer>();

        // assuming the first available WebCam is desired

        //WebCamTexture tex = new WebCamTexture(devices[0].name);
        WebCamTexture tex = new WebCamTexture(devices[kandaoMeetingIndex].name);
        //WebCamTexture tex = new WebCamTexture(devices[OBSVirtualCameraIndex].name);

        //rend.material.mainTexture = tex;
        rawImage0.texture = tex;
        rawImage1.texture = tex;
        duplicateRawImage0.texture = tex;
        duplicateRawImage1.texture = tex;

        tex.Play();
    }
}