using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : SubPanelManager
{
    [SerializeField]
    VideoStreamer rawFeed_VideoStreamer;

    bool streamStarted = false;

    [SerializeField]
    bool camNotTrilobot = false;

    void Start()
    {
        //if (camNotTrilobot)
        //{
        //    uri = GameManager.Instance.videoSources[0].GetVideoURL();
        //}
        //else
        //{
        //    uri = GameManager.Instance.trilobots[0].GetVideoURL();
        //}
        //Debug.Log(uri);
    }


    //void Update()
    //{
    //    FirstStartStream();

    //}

    override protected void UpdateRunning()
    {
        FirstStartStream();
    }

    public void BootStream(string uri)
    {
        this.uri = uri;
        FirstStartStream();
    }

    void FirstStartStream()
	{
        if (!streamStarted && uri != "")
        {
            streamStarted = true;
            rawFeed_VideoStreamer.StartStream(uri);
        }
    }

    void RestartStream(string uri)
	{
        streamStarted = true;
        rawFeed_VideoStreamer.ResetStream(uri);
    }

}
