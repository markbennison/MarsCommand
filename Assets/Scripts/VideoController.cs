using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    VideoStreamer rawFeed_VideoStreamer;
    [SerializeField]
    string url = "";
    bool streamStarted = false;

    [SerializeField]
    bool camNotTrilobot = false;

    void Start()
    {
        if (camNotTrilobot)
        {
            url = GameManager.Instance.videoSources[0].GetVideoURL();
        }
        else
        {
            url = GameManager.Instance.trilobots[0].GetVideoURL();
        }
        //Debug.Log(url);
    }


    void Update()
    {
        FirstStartStream();

    }

    public void BootStream(string url)
    {
        this.url = url;
        FirstStartStream();
    }

    void FirstStartStream()
	{
        if (!streamStarted && url != "")
        {
            streamStarted = true;
            rawFeed_VideoStreamer.StartStream(url);
        }
    }

    void RestartStream(string url)
	{
        streamStarted = true;
        rawFeed_VideoStreamer.ResetStream(url);
    }
}
