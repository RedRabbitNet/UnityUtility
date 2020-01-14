using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


[Serializable] public class UnityEventInt : UnityEvent<int> { }

[Serializable]
public class EventValue
{

    [SerializeField] private int actualValue;                       //変動する実際の数値
    public UnityEventInt OnChangeValue = new UnityEventInt();     //変化した時のコールバック(引数：差分)

    public int access                                               //プロパティアクセス
    {
        get { return this.actualValue; }
        set
        {

            int beforeValue = this.actualValue; //変更前の値を保存
            this.actualValue = value;           //変更を確定

            //各種コールバックの起動
            OnChangeValue.Invoke(this.actualValue - beforeValue);
        }
    }

    //演算子オーバーロード
    public static EventValue operator +(EventValue targetValue, int addValue)
    {
        targetValue.access += addValue;
        return targetValue;
    }
    public static EventValue operator -(EventValue targetValue, int addValue)
    {
        targetValue.access -= addValue;
        return targetValue;
    }
    public static EventValue operator *(EventValue targetValue, int addValue)
    {
        targetValue.access *= addValue;
        return targetValue;
    }
    public static EventValue operator /(EventValue targetValue, int addValue)
    {
        targetValue.access /= addValue;                                                     //整数割り算注意
        return targetValue;
    }

    public static bool operator <(EventValue targetValue, int addValue)
    {
        return targetValue.access < addValue;
    }
    public static bool operator >(EventValue targetValue, int addValue)
    {
        return targetValue.access > addValue;
    }
    public static bool operator <=(EventValue targetValue, int addValue)
    {
        return targetValue.access <= addValue;
    }
    public static bool operator >=(EventValue targetValue, int addValue)
    {
        return targetValue.access >= addValue;
    }

    public static EventValue operator +(EventValue targetValue, EventValue addValue)
    {
        targetValue.access += addValue.access;
        return targetValue;
    }
    public static EventValue operator -(EventValue targetValue, EventValue addValue)
    {
        targetValue.access -= addValue.access;
        return targetValue;
    }
    public static EventValue operator *(EventValue targetValue, EventValue addValue)
    {
        targetValue.access *= addValue.access;
        return targetValue;
    }
    public static EventValue operator /(EventValue targetValue, EventValue addValue)
    {
        targetValue.access /= addValue.access;
        return targetValue;
    }

    //型変換オーバーロード
    public static explicit operator int(EventValue targetValue) { return ((int)targetValue.actualValue); }
    public static explicit operator float(EventValue targetValue) { return ((float)targetValue.actualValue); }
}