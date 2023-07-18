using System.Collections;
using System.Collections.Generic;

public class Trilobot : Device
{
    string defaultName = "Unknown Trilobot";
    int defaultPort = 8080;

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
        port = defaultPort;
    }

    public Trilobot(int ip1, int ip2, int ip3, int ip4)
    {
        Name = defaultName;
        this.ip1 = ip1;
        this.ip2 = ip2;
        this.ip3 = ip3;
        this.ip4 = ip4;
        port = defaultPort;
    }

    public Trilobot(int ip1, int ip2, int ip3, int ip4, int port)
    {
        Name = defaultName;
        this.ip1 = ip1;
        this.ip2 = ip2;
        this.ip3 = ip3;
        this.ip4 = ip4;
        this.port = port;
    }

    public Trilobot(string name, int ip1, int ip2, int ip3, int ip4, int port)
    {
        Name = name;
        this.ip1 = ip1;
        this.ip2 = ip2;
        this.ip3 = ip3;
        this.ip4 = ip4;
        this.port = port;
    }

    public string GetVideoURL()
    {
        return GetURLAndPort() + videolink;
    }

    public string GetMainURL()
    {
        return "http://" + ip1 + "." + ip2 + "." + ip3 + "." + ip4 + ":" + mainBoardPort;
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
