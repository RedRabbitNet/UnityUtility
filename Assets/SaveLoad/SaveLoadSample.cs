using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSample : MonoBehaviour {

	[System.Serializable]
	public class SampleData
	{
		public int virtualCoin;
	}
	private SampleData data;
	const string fileName = "SampleData.json";

	// Use this for initialization
	void Start () {
		data = SaveLoad.Load<SampleData>(fileName);
		//data = new SampleData();
		Debug.Log("virtualCoin:" + data.virtualCoin);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.A))
		{
			data.virtualCoin++;
			Debug.Log("virtualCoin:" + data.virtualCoin);
		}

		if (Input.GetKeyDown(KeyCode.S))
			SaveLoad.Save<SampleData>(fileName, data);
	}
}
