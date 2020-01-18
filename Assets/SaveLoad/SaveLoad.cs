using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// SaveLoadに関する機能をまとめたクラス
/// JsonUtilityを扱うため、保存されるデータはpublicまたはSerializeFieldであることに注意。
/// </summary>
static public class SaveLoad
{
	static public void Save<Type>(string fileName, Type data)
	{
		Debug.Log("Save:" + fileName);
		File.WriteAllText(Application.streamingAssetsPath + "/" + fileName, JsonUtility.ToJson(data, true));
	}

	static public Type Load<Type>(string fileName)
	{
		Debug.Log("Load:" + fileName);
		return JsonUtility.FromJson<Type>(File.ReadAllText(Application.streamingAssetsPath + "/" + fileName));
	}
}
