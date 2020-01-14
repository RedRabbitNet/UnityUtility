using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventValueSample : MonoBehaviour {
    private EventValue eventsValue = new EventValue();

    public void Start()
    {
        //コールバックの指定
        eventsValue.OnChangeValue.AddListener(TestCall);

        //値の変更
        eventsValue.access = 3;
        eventsValue.access = 5;
        eventsValue.access -= 4;
    }

    //サンプル用実行関数
    public void TestCall(int diff)
    {
        Debug.Log("TestCall" + diff);
    }
}
