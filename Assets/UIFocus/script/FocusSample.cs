using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusSample : MonoBehaviour {
	[SerializeField] private FocusButton focusButton;

	// Use this for initialization
	void Start () {
		//１つのUIを除いて選択不能にする
		focusButton.Focus();
	}
	
	//ボタン動作確認用
	public void ClickLog()
	{
		Debug.Log("OnClick");
	}
}
