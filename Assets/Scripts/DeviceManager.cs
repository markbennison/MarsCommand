using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeviceManager : SubPanelManager
{
    [SerializeField]
    Transform panelList;

    [SerializeField]
    GameObject deviceButtonPrefab;

    [SerializeField]
    IPNumberController ipNumberController;

    void Start()
    {
        GrabDevices();
        ipNumberController.SetIP(192, 168, 8, 0);
    }

    void Update()
    {
        
    }
    public void Initiate(string uri)
    {
        if (uri == "")
        {
            return;
        }

        string[] uriSections = uri.Split('.');
        if (uriSections.Length != 4)
        {
            return;
        }

        int a, b, c, d;

        if (
            int.TryParse(uriSections[0], out a) &&
            int.TryParse(uriSections[1], out b) &&
            int.TryParse(uriSections[2], out c) &&
            int.TryParse(uriSections[3], out d))
        {

            ipNumberController.SetIP(a,b,c,d);
        }

    }

    void GrabDevices()
    {
        List<string> deviceList = GameManager.Instance.GetDeviceNames();
        ClearList();
        GameObject gameObject;
        
        for (int i = 0; i < deviceList.Count; i++)
        {
            gameObject = Instantiate(deviceButtonPrefab, panelList);
            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = deviceList[i];
            gameObject.GetComponent<Button>().AddEventListener(i, DeviceButtonClicked);
        }

    }

    void ClearList()
    {
        foreach (Transform child in panelList)
        {
            Destroy(child.gameObject);
        }
    }

    void DeviceButtonClicked(int index)
    {
        GameManager.Instance.RemoveDevice(index);
        GrabDevices();
    }

    public void AddVideoSource()
	{
        GameManager.Instance.videoSources.Add(new VideoSource(
            ipNumberController.GetNumber1(), 
            ipNumberController.GetNumber2(), 
            ipNumberController.GetNumber3(), 
            ipNumberController.GetNumber4()));

        GrabDevices();
    }

    public void AddTrilobot()
	{
        GameManager.Instance.trilobots.Add(new Trilobot(
            ipNumberController.GetNumber1(), 
            ipNumberController.GetNumber2(), 
            ipNumberController.GetNumber3(), 
            ipNumberController.GetNumber4())); ;

        GrabDevices();
    }

}

