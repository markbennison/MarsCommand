using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSource : Device
{
	string defaultName = "Unknown Source";
	int defaultPort = 8080;

	string videolink = "/video_feed";

	public VideoSource(string name, int ip1, int ip2, int ip3, int ip4)
	{
		Name = name;
		this.ip1 = ip1;
		this.ip2 = ip2;
		this.ip3 = ip3;
		this.ip4 = ip4;
		port = defaultPort;
	}

	public VideoSource(int ip1, int ip2, int ip3, int ip4)
	{
		Name = defaultName;
		this.ip1 = ip1;
		this.ip2 = ip2;
		this.ip3 = ip3;
		this.ip4 = ip4;
		port = defaultPort;
	}

	public VideoSource(int ip1, int ip2, int ip3, int ip4, int port)
	{
		Name = defaultName;
		this.ip1 = ip1;
		this.ip2 = ip2;
		this.ip3 = ip3;
		this.ip4 = ip4;
		this.port = port;
	}

	public VideoSource(string name, int ip1, int ip2, int ip3, int ip4, int port)
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
