using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device
{
	public string Name { get; set; }

	protected int ip1, ip2, ip3, ip4, port;

    public Device()
    {

    }

    public Device(string name, int ip1, int ip2, int ip3, int ip4)
    {
        Name = name;
        this.ip1 = ip1;
        this.ip2 = ip2;
        this.ip3 = ip3;
        this.ip4 = ip4;
    }

    public Device(int ip1, int ip2, int ip3, int ip4)
    {
        this.ip1 = ip1;
        this.ip2 = ip2;
        this.ip3 = ip3;
        this.ip4 = ip4;
    }

    public string GetIP()
    {
        return ip1 + "." + ip2 + "." + ip3 + "." + ip4;
    }

    public string GetURLAndPort()
    {
        return "http://" + GetIP() + ":" + port;
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
