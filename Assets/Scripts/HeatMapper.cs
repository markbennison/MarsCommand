using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
//using Leguar.TotalJSON;

public class HeatMapper : JsonGrabber
{
	[SerializeField]
	GameObject heatPixelPrefab;

	[SerializeField]
	GameObject heatMapGameObject;

	[SerializeField]
	GameObject heatScaleGameObject;

	int pixelDimension = 18;

	float minTemperature, maxTemperature;

	[SerializeField]
	string heatMapURI = "http://192.168.8.104:5002/heatmap/simplerows";

	List<List<GameObject>> gridMap = new List<List<GameObject>>();
	List<List<float>> floatMap = new List<List<float>>();
	List<GameObject> heatScale = new List<GameObject>();

	float timer = 0f;

	void Start()
	{
		heatMapURI = GameManager.Instance.trilobots[0].GetHeatMapURL();

		minTemperature = 300;
		maxTemperature = -40;

		CreateSquareGrid(32, 24);
		CreateScale(100);
		SetScale(100);

		//StartCoroutine(base.GetText(heatMapURI));
	}

	void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			timer = 2f;
			StartCoroutine(base.GetText(heatMapURI));
		}
	}

	void CreateScale(int range)
	{
		for (int i = 0; i < range; i++)
		{
			heatScale.Add(Instantiate(heatPixelPrefab, heatScaleGameObject.transform));
		}
	}

	void CreateSquareGrid(int pixelsAcross, int pixelsDown)
	{
		int topXValue = pixelsDown * pixelDimension;

		for (int y = 0; y < pixelsDown; y++)
		{
			gridMap.Add(new List<GameObject>());
			for (int x = 0; x < pixelsAcross; x++)
			{
				gridMap[y].Add(Instantiate(heatPixelPrefab, heatMapGameObject.transform));
			}
		}
	}

	override protected void JsonRetrieved()
	{
		json = json.Remove(0, 8);
		json = json.Remove(json.Length - 4, 4);

		List<string> stringRows = new List<string>();
		floatMap.Clear();
		float tempValue;

		foreach (string row in json.Split(']'))
		{
			stringRows.Add(row.Remove(0, 2));
		}

		for (int i = 0; i < stringRows.Count; i++)
		{
			string[] stringColumns = stringRows[i].Split(',');
			floatMap.Add(new List<float>());
			foreach (string item in stringColumns)
			{
				tempValue = float.Parse(item.Trim('"'));
				ResetLowerHigherValues(tempValue);
				floatMap[i].Add(tempValue);
			}
		}
		MapToGrid();
	}

	void SetScale(float range)
	{
		float value, hue;
		for (int i = 0; i < range; i++)
		{
			value = i / range;
			hue = (1 - value) * 0.7f;
			heatScale[i].GetComponent<Image>().color = Color.HSVToRGB(hue, 1, 1);
		}
	}

	void MapToGrid()
	{
		for (int y = 0; y < gridMap.Count; y++)
		{
			for (int x = 0; x < gridMap[y].Count; x++)
			{
				//gridMap[y][x].GetComponent<Image>().color = HeatToGreyscale(floatMap[y][x]);
				gridMap[y][x].GetComponent<Image>().color = HeatToShortRainbow(floatMap[y][x]);
			}
		}
	}

	void ResetLowerHigherValues(float value)
	{
		if(minTemperature > value)
		{
			minTemperature = value;
		}
		if(maxTemperature < value)
		{
			maxTemperature = value;
		}
	}

	Color32 HeatToGreyscale(float value)
	{
		if (value < minTemperature)
		{
			value = minTemperature;
		}
		else if (value > maxTemperature)
		{
			value = maxTemperature;
		}

		value -= minTemperature;
		value = value / (maxTemperature - minTemperature);
		value *= 255;

		return new Color32((byte)value, (byte)value, (byte)value, 255);
	}

	Color32 HeatToShortRainbow(float value)
	{
		if (value < minTemperature)
		{
			value = minTemperature;
		}
		else if (value > maxTemperature)
		{
			value = maxTemperature;
		}

		value -= minTemperature;
		value = value / (maxTemperature - minTemperature);
		float hue = (1 - value) * 0.7f;
		return Color.HSVToRGB(hue, 1, 1);
	}
}