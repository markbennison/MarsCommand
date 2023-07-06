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
	int pixelDimension = 18;

	[SerializeField]
	float lowestTempRange = 0f;
	[SerializeField]
	float highestTempRange = 100f;
	float TempRange;

	[SerializeField]
	string heatMapURI = "http://192.168.8.104:5002/heatmap/simplerows";

	List<List<GameObject>> gridMap = new List<List<GameObject>>();
	List<List<float>> floatMap = new List<List<float>>();

	float timer = 0f;

	void Start()
	{
		TempRange = highestTempRange - lowestTempRange;
		CreateSquareGrid(32, 24);
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


	void CreateSquareGrid(int pixelsAcross, int pixelsDown)
	{
		int topXValue = pixelsDown * pixelDimension;

		for (int y = 0; y < pixelsDown; y++)
		{
			gridMap.Add(new List<GameObject>());
			for (int x = 0; x < pixelsAcross; x++)
			{
				gridMap[y].Add(Instantiate(heatPixelPrefab, gameObject.transform));
			}
		}
	}

	override protected void JsonRetrieved()
	{
		json = json.Remove(0, 8);
		json = json.Remove(json.Length - 4, 4);

		List<string> stringRows = new List<string>();
		floatMap.Clear();

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
				floatMap[i].Add(float.Parse(item.Trim('"')));
			}
		}

		MapToGrid();
	}


	void MapToGrid()
	{
		for (int y = 0; y < gridMap.Count; y++)
		{
			for (int x = 0; x < gridMap[y].Count; x++)
			{
				//Debug.Log(floatMap[y][x] + " || " + gridMap[y][x]);
				Debug.Log(gridMap[y][x]);
				//gridMap[y][x].GetComponent<Image>().color = HeatToColor(20);
				gridMap[y][x].GetComponent<Image>().color = HeatToShortRainbow(floatMap[y][x]);
			}
		}
	}

	Vector3 GridPosition(float x, float y)
	{
		x *= pixelDimension;
		y *= pixelDimension;

		x += gameObject.transform.position.x;
		y -= gameObject.transform.position.y;
		//Debug.Log("x:" + x + "  | y:" + y + "    position: " + gameObject.transform.position.ToString());
		return new Vector3(x, y, 0);
	}

	Color32 HeatToColor(float value)
	{
		if (value < lowestTempRange)
		{
			value = lowestTempRange;
		}
		else if (value > highestTempRange)
		{
			value = highestTempRange;
		}

		value -= lowestTempRange;
		value = value / highestTempRange;
		value *= 255;

		return new Color32((byte)value, (byte)value, (byte)value, 255);
	}

	Color32 HeatToShortRainbow(float value)
	{
		if (value < lowestTempRange)
		{
			value = lowestTempRange;
		}
		else if (value > highestTempRange)
		{
			value = highestTempRange;
		}

		value -= lowestTempRange;
		value = value / highestTempRange;

		return Color.HSVToRGB(1-value, 1, 1);
	}


}