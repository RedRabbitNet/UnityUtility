using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusButton : Button{
	public void Focus()
	{
		foreach (Selectable selectableUI in Selectable.allSelectables)
		{
			//コンポーネントがアタッチされているオブジェクト以外のUI要素を無効にする
			if (selectableUI.gameObject != this.gameObject)
			{
				selectableUI.interactable = false;
				Debug.Log(selectableUI.name);
			}
			else
			{
				selectableUI.interactable = true;
			}
		}
	}
}
