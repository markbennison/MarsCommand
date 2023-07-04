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
	float lowestTempRange = 10f;
	[SerializeField]
	float highestTempRange = 30f;
	float TempRange;

	[SerializeField]
	string heatMapURI = "http://192.168.8.104:5002/heatmap/simplerows";

	List<List<GameObject>> gridMap = new List<List<GameObject>>();
	//JSON jsonObject = new JSON();

	void Start()
	{
		TempRange = highestTempRange - lowestTempRange;
		CreateSquareGrid(32, 20);


		StartCoroutine(base.GetText(heatMapURI));


	}

	override protected void JsonRetrieved()
	{
		Debug.Log(json);
		//JArray jsonArray = jsonObject.GetJArray("numberArray"); // Contains ints 1,2,4,8
		//StringToIntList(json);
		json = json.Remove(0, 8);
		json = json.Remove(json.Length - 4, 3);
		Debug.Log(json);

		List<string> stringRows = new List<string>();
		List<List<float>> floatMap = new List<List<float>>();

		foreach (string row in json.Split(']'))
		{
			stringRows.Add(row.Remove(0, 2));
		}

		for (int i = 0; i < stringRows.Count - 1; i++)
		{
			string[] stringColumns = stringRows[i].Split(',');
			floatMap.Add(new List<float>());
			foreach (string item in stringColumns)
			{
				floatMap[i].Add(float.Parse(item.Trim('"')));
			}
		}

		//Debugger
		for (int y = 0; y < floatMap.Count - 1; y++)
		{
			
			for (int x = 0; x < floatMap[y].Count - 1; x++)
			{
				
				//GameObject pixel = Instantiate(heatPixelPrefab, new Vector3(x * 20f, y * 20f, 0), Quaternion.identity, gameObject.transform);
				//pixel.GetComponent<RawImage>().color = HeatColor(item);
			}
		}


	}

	void CreateSquareGrid(int pixelsAcross, int pixelsDown)
	{
		int topXValue = pixelsDown * 20;

		for (int y = 0; y < pixelsDown - 1; y++)
		{
			gridMap.Add(new List<GameObject>());
			for (int x = 0; x < pixelsAcross - 1; x++)
			{
				gridMap[y].Add(Instantiate(heatPixelPrefab, gameObject.transform));
				//gridMap[x]
				//gridMap[y].Add(Instantiate(heatPixelPrefab, new Vector3(x * 20f, 0 - (y * 20f), 0), Quaternion.identity, gameObject.transform));
				//gridMap[y].Add(Instantiate(heatPixelPrefab, gameObject.transform, false));
				//gridMap[y][x].transform.position = new Vector3(x * 20f, 0 - (y * 20f), 0);

			}
		}

	}

	Vector3 GridPosition(float x, float y)
	{
		x *= 20;
		y *= 20;

		x += gameObject.transform.position.x;
		y -= gameObject.transform.position.y;
		Debug.Log("x:" + x + "  | y:" + y + "    position: " + gameObject.transform.position.ToString());
		return new Vector3(x, y, 0);
	}

	Color HeatColor(float value)
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

		return new Color(value, value, value);
	}


}