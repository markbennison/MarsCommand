using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSettings : MonoBehaviour
{
    [SerializeField]
    GameObject settingsMenu;
	
    [SerializeField]
	GameObject loadSubPanel;

    bool settingsOpen;

	// Start is called before the first frame update
	void Start()
    {
		toggleSettingsStatus(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplaySettings()
    {
        if (settingsOpen)
        {
			toggleSettingsStatus(false);

            return;
		}
		

		List<string> menuOptions = new List<string>();

        if (GameManager.Instance.videoSources.Count > 0)
        {
            foreach (VideoSource videoSource in GameManager.Instance.videoSources)
            {
                menuOptions.Add(videoSource.Name);
            }
        }
        if (GameManager.Instance.trilobots.Count > 0)
        {
            foreach (Trilobot trilobots in GameManager.Instance.trilobots)
            {
                menuOptions.Add(trilobots.Name);
            }
        }

        foreach (string menuItem in menuOptions)
        {
            Debug.Log(menuItem);
        }

		toggleSettingsStatus(true);
	}

    void toggleSettingsStatus(bool active)
    {
		settingsOpen = active;
		settingsMenu.SetActive(active);
	}
}
