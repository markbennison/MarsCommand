using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelSettings : MonoBehaviour
{
    [SerializeField]
    GameObject settingsMenu;
	
    [SerializeField]
	Transform subPanelMask;

	[SerializeField]
	Transform panelOptionsList;

	[SerializeField]
	GameObject settingsButtonPrefab;

	bool settingsOpen;

    bool subPanelActive = false;

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

		if (subPanelActive)
		{
			InitialiseClosePanelSetting();
		}
		else
		{
			InitialiseSettingsList();
		}

		toggleSettingsStatus(true);
	}

    void toggleSettingsStatus(bool active)
    {
		settingsOpen = active;
		settingsMenu.SetActive(active);
	}

	//
	//
	//

	void InitialiseSettingsList()
	{
		List<string> menuOptions = GameManager.Instance.GetSettingsOptions();

		ClearSettingsList();
		GameObject gameObject;

		for (int i = 0; i < menuOptions.Count; i++)
		{
			gameObject = Instantiate(settingsButtonPrefab, panelOptionsList);
			gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = menuOptions[i];
			gameObject.GetComponent<Button>().AddEventListener(i, SettingsOptionClicked);
		}
	}

	void InitialiseClosePanelSetting()
	{
		ClearSettingsList();
		GameObject gameObject = Instantiate(settingsButtonPrefab, panelOptionsList);
		gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Close Panel";
		gameObject.GetComponent<Button>().AddEventListener(0, CloseButtonClicked);
	}

	void ClearSettingsList()
	{
		foreach (Transform child in panelOptionsList)
		{
			Destroy(child.gameObject);
		}
	}

	void SettingsOptionClicked(int index)
	{
		GameObject panel = Instantiate(GameManager.Instance.PanelByIndex(index), subPanelMask);
		panel.GetComponent<SubPanelManager>().Initiate(GameManager.Instance.UriByIndex(index));
		subPanelActive = true;
		DisplaySettings();
	}

	void CloseButtonClicked(int index)
	{
		Debug.Log("Close");
		foreach (Transform child in subPanelMask)
		{
			Destroy(child.gameObject);
		}
		subPanelActive = false;
		DisplaySettings();
	}

}
public static class ButtonExtension
{
	public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
	{
		button.onClick.AddListener(delegate () { OnClick(param); });
	}
}

