using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : MonoBehaviour
{
    public int Day
    {
        get { return PlayerPrefs.GetInt("Day"); }
        set { PlayerPrefs.SetInt("Day", Day + value); }
    }
    public delegate void DayChangedDelegate(int newDay);
    public static event DayChangedDelegate OnDayChanged;
    public int Money
    {
        get {return PlayerPrefs.GetInt("Money"); }
        set {PlayerPrefs.SetInt("Money",Money+ value);}
    }
    public delegate void MoneyChangedDelegate(int newMoney);
    public static event MoneyChangedDelegate OnMoneyChanged;

    public int Level
    {
        get{return PlayerPrefs.GetInt("Level", 1);}
        set{PlayerPrefs.SetInt("Level",Level + value);}
    }
    public delegate void LevelChangedDelegate(int newLevel);
    public static event LevelChangedDelegate OnLevelChanged;

    public bool OnMoneyEnoughChanged(int _Money) { return Money > _Money ? true : false; }
    public bool OnLevelEnoughChanged(int _Level) { return Level >= _Level ? true : false; }

    public static GameManager instance;
    private IEnumerator Start()
    {
        Events.MoneyChangeAction += OnMoneyChange;
        Events.LevelChangeAction += OnLevelChange;

        instance = this;

        yield return new WaitForSeconds(0.1f);
        OnMoneyChange(0);
        OnLevelChange(0);
    }
    private void OnDestroy()
    {
        Events.MoneyChangeAction -= OnMoneyChange;
        Events.LevelChangeAction -= OnLevelChange;
    }
    public void OnMoneyChange(int i)
    {
        Money = i;
        if (OnMoneyChanged != null) OnMoneyChanged(Money);
    }
    public void OnLevelChange(int i)
    {
        Level = i;
        Events.LevelIncreasedChangeAction?.Invoke(Level);
        if (OnLevelChanged != null) OnLevelChanged(Level);
    }
    public void OnDayChange(int i)
    {
        Day = i;
        if (OnDayChanged != null) OnDayChanged(Day);
    }
}
