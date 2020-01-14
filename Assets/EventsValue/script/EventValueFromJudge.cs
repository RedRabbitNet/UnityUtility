using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

/// <summary>
/// 変更された値が特定条件を満たす場合にイベント関数を呼ぶ仕組みを実装するクラス
/// 条件式をJudgeFunctionに設定することができる
/// </summary>
[Serializable]
public class EventValueFromJudge
{
    private int actualValue;                        //変動する実際の数値
    public UnityEvent OnChanged = new UnityEvent(); //変動した時のコールバック
    public Func<int,bool> JudgeFunction;            //変動した値を引数とする条件判定関数

    public int access                               //プロパティアクセス
    {
        get { return this.actualValue; }
        set
        {
            //値の書き換え
            actualValue = value;

            //各種コールバックの起動
            if (JudgeFunction(actualValue))
                OnChanged.Invoke();
        }
    }
}
