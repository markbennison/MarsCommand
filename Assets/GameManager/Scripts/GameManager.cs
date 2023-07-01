using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // DESIGN PATTERN: SINGLETON
    public static GameManager Instance { get; private set; }
	//public UIManager UIManager { get; private set; }
	public List<VideoSource> videoSources = new List<VideoSource>();
	public List<Rover> rovers = new List<Rover>();

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
    }

    void Start()
    {
		//CAM1
		//http://192.168.8.134:5000/video_feed

		//Rover
		//http://192.168.8.104:8080/video_feed

		videoSources.Clear();
		videoSources.Add(new VideoSource("Test Camera", 192, 168, 8, 134, 5000));

		rovers.Clear();
        rovers.Add(new Rover("Test Rover", 192, 168, 8, 104, 8080));


	}

	void Update()
    {

    }


}