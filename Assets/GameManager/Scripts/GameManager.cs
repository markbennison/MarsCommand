using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // DESIGN PATTERN: SINGLETON
    public static GameManager Instance { get; private set; }
	//public UIManager UIManager { get; private set; }
	public List<VideoSource> videoSources = new List<VideoSource>();
	public List<Trilobot> trilobots = new List<Trilobot>();

    Color uiColour = new Color(102,187,187);

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
        videoSources.Add(new VideoSource("Test Camera", 192, 168, 8, 134, 8080));

        trilobots.Clear();
        trilobots.Add(new Trilobot("Test Trilobot", 192, 168, 8, 104));

    }

    void Start()
    {
		//CAM1
		//http://192.168.8.134:5000/video_feed

		//Rover
		//http://192.168.8.104:8080/video_feed



	}

	void Update()
    {

    }


}