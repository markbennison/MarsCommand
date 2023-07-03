using System.Collections;
using System.Collections.Generic;

public class Rover
{
	public string Name { get; set; }

	string deviceName = "Unknown Rover";
    int ip1, ip2, ip3, ip4;
    int port;
    string videolink = "/video_feed";


    public Rover()
    {

    }

	public Rover(string name, int ip1, int ip2, int ip3, int ip4, int port)
	{
		Name = name;
		this.ip1 = ip1;
		this.ip2 = ip2;
		this.ip3 = ip3;
		this.ip4 = ip4;
		this.port = port;
	}

	public Rover(string name, string deviceName, int ip1, int ip2, int ip3, int ip4, int port, string videolink)
    {
        Name = name;
        this.deviceName = deviceName;
        this.ip1 = ip1;
        this.ip2 = ip2;
        this.ip3 = ip3;
        this.ip4 = ip4;
        this.port = port;
        this.videolink = videolink;
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

    public string GetURLandPort()
    {
        return "http://" + ip1 + "." + ip2 + "." + ip3 + "." + ip4 + ":" + port;
    }

    public string GetVideoURL()
    {
		return ip1 + "." + ip2 + "." + ip3 + "." + ip4 + ":" + port + videolink;
	}

    public void SetIP(int first, int second, int third, int fourth)
    {
        ip1 = first;
        ip2 = second;
        ip3 = third;
        ip4 = fourth;
    }

	public void SetIP(int first, int second, int third, int fourth, int port)
	{
		ip1 = first;
		ip2 = second;
		ip3 = third;
		ip4 = fourth;
        this.port = port;
	}

}
