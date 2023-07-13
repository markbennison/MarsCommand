using System.Collections;
using System.Collections.Generic;

public class Trilobot
{
	public string Name { get; set; }

	string deviceName = "Unknown Rover";
    int ip1, ip2, ip3, ip4;

    int atmosphericPort = 5000;
    int mainBoardPort = 5001;
    int heatSensorPort = 5002;
    int cameraPort = 8080;

    string videolink = "/video_feed";
    string heatMapRows = "/heatmap/simplerows";

    public Trilobot(string name, int ip1, int ip2, int ip3, int ip4)
    {
        Name = name;
        this.ip1 = ip1;
        this.ip2 = ip2;
        this.ip3 = ip3;
        this.ip4 = ip4;
    }

    public Trilobot(int ip1, int ip2, int ip3, int ip4)
    {
        this.ip1 = ip1;
        this.ip2 = ip2;
        this.ip3 = ip3;
        this.ip4 = ip4;
    }

    public string GetDeviceName()
    {
        return deviceName;
    }

    public string GetIP()
    {
        return ip1 + "." + ip2 + "." + ip3 + "." + ip4;
    }

	public string GetURL()
	{
		return "http://" + ip1 + "." + ip2 + "." + ip3 + "." + ip4;
	}

    public string GetVideoURL()
    {
		return "http://" + ip1 + "." + ip2 + "." + ip3 + "." + ip4 + ":" + cameraPort + videolink;
	}
    public string GetMainURL()
    {
        return "http://" + ip1 + "." + ip2 + "." + ip3 + "." + ip4 + ":" + mainBoardPort + videolink;
    }

    public string GetControlURL()
    {
        return GetMainURL();
    }

    public string GetDistanceURL()
    {
        return GetMainURL();
    }

    public string GetUnderlightURL()
    {
        return GetMainURL();
    }

    public string GetAtmosphericURL()
    {
        return "http://" + ip1 + "." + ip2 + "." + ip3 + "." + ip4 + ":" + atmosphericPort;
    }

    public string GetHeatMapURL()
	{
        return "http://" + ip1 + "." + ip2 + "." + ip3 + "." + ip4 + ":" + heatSensorPort + heatMapRows;
    }

    public void SetIP(int first, int second, int third, int fourth)
    {
        ip1 = first;
        ip2 = second;
        ip3 = third;
        ip4 = fourth;
    }
}
