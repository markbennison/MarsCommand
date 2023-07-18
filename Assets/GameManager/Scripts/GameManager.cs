using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // DESIGN PATTERN: SINGLETON
    public static GameManager Instance { get; private set; }
    //public UIManager UIManager { get; private set; }

    List<Device> devices = new List<Device>();
    public List<VideoSource> videoSources = new List<VideoSource>();
    public List<Trilobot> trilobots = new List<Trilobot>();

    [SerializeField] GameObject panelDevices;

    [SerializeField] GameObject panelVideo;
    [SerializeField] GameObject panelHeat;
    [SerializeField] GameObject panelAtmospheric;
    [SerializeField] GameObject panelStatus;
    [SerializeField] GameObject panelControl;

    List<string> settingsOptions = new List<string>();
    List<GameObject> settingsPanels = new List<GameObject>();
    List<string> settingsURI = new List<string>();

    Color uiColour = new Color(102, 187, 187);

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        //UIManager = GetComponent<UIManager>();

        videoSources.Clear();
        //videoSources.Add(new VideoSource("Test Camera", 192, 168, 8, 134));

        trilobots.Clear();
        //trilobots.Add(new Trilobot("Test Trilobot", 192, 168, 8, 104));

    }

    void Start()
    {
        //CAM1
        //http://192.168.8.134:8080/video_feed

        //Rover
        //http://192.168.8.104:8080/video_feed


    }

    void Update()
    {

    }

    public List<string> GetDeviceNames()
	{
        List<string> list = new List<string>();
        RefreshDevices();

        foreach (Device device in devices)
        {
            list.Add(device.Name);
        }

        return list;
    }

    public List<string> GetDeviceNamesAndTypes()
    {
        List<string> list = new List<string>();
        RefreshDevices();

        foreach (Device device in devices)
        {
            list.Add(device.Name + " (" + device.GetType() + ")");
        }

        return list;
    }



    void RefreshDevices()
    {
        devices.Clear();

        foreach (VideoSource videoSource in videoSources)
        {
            devices.Add(videoSource);
        }

        foreach (Trilobot trilobot in trilobots)
        {
            devices.Add(trilobot);
        }
    }

    public void RemoveDevice(int index)
	{
        Debug.Log("REMOVE: " + index);
        int offsetIndex = 0;

        if (devices.Count == 0)
		{
            Debug.Log("NO DEVICES");
            return;
		}

        if(devices[index] is VideoSource)
		{
            offsetIndex = index;
            Debug.Log("VideoSource at " + offsetIndex);
            videoSources.RemoveAt(offsetIndex);
            return;
        }

        if (devices[index] is Trilobot)
        {
            offsetIndex = index - videoSources.Count;
            Debug.Log("Trilobot at " + offsetIndex);
            trilobots.RemoveAt(offsetIndex);
            return;
        }
        RefreshDevices();
    }

    public GameObject PanelByIndex(int index)
	{
        return settingsPanels[index];
    }

    public string UriByIndex(int index)
    {
        return settingsURI[index];
    }

    public List<string> GetSettingsOptions()
	{
        InitialiseSettings();
        return settingsOptions;
    }

    public void InitialiseSettings()
	{
        int v = 0;
        int t = 0;

        settingsOptions.Clear();
        settingsPanels.Clear();
        settingsURI.Clear();

        foreach (VideoSource videoSource in videoSources)
		{
            v++;
            settingsOptions.Add("Video Feed " + v);
            settingsPanels.Add(panelVideo);
            settingsURI.Add(videoSource.GetVideoURL());
        }

        foreach (Trilobot trilobot in trilobots)
        {
            t++;
            settingsOptions.Add("T-bot " + t + " Status");
            settingsPanels.Add(panelStatus);
            settingsURI.Add(trilobot.GetMainURL());

            settingsOptions.Add("T-bot " + t + " Camera");
            settingsPanels.Add(panelVideo);
            settingsURI.Add(trilobot.GetVideoURL());

            settingsOptions.Add("T-bot " + t + " Thermal");
            settingsPanels.Add(panelHeat);
            settingsURI.Add(trilobot.GetHeatMapURL());

            settingsOptions.Add("T-bot " + t + " Atmospherics");
            settingsPanels.Add(panelAtmospheric);
            settingsURI.Add(trilobot.GetAtmosphericURL());

            settingsOptions.Add("T-bot " + t + " Control");
            settingsPanels.Add(panelControl);
            settingsURI.Add(trilobot.GetMainURL());
        }

        settingsOptions.Add("* Device Manager *");
        settingsPanels.Add(panelDevices);
        settingsURI.Add("192.168.8.0");
    }

}