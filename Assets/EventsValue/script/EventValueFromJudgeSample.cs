using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventValueFromJudgeSample : MonoBehaviour {
    private EventValueFromJudge eventsValue = new EventValueFromJudge();

    public void Start()
    {

        //実行条件の設定
        eventsValue.JudgeFunction = Judge;

        //コールバックの指定
        eventsValue.OnChanged.AddListener(TestCall);

        //値の変更
        eventsValue.access = 3;
        eventsValue.access = 5;
    }

    //サンプル用コールバック条件式
    public bool Judge(int a)
    {
        return a > 3;
    }

    //サンプル用実行関数
    public void TestCall()
    {
        Debug.Log("TestCall");
    }
}
