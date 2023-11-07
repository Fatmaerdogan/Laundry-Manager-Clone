using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{

    [Header("Text")]
    public TMP_Text MoneyText,LevelText,DayText;

    private void Start()
    {
        GameManager.OnMoneyChanged += MoneyTextChanged;
        GameManager.OnLevelChanged += LevelTextChanged;
        GameManager.OnDayChanged += DayTextChanged;
    }
    public void MoneyTextChanged(int Money) => MoneyText.text = (Money / 1000)+"."+(Money%1000)/100 + "K";
    public void LevelTextChanged(int Level) => LevelText.text = "LEVEL : "+Level;
    public void DayTextChanged(int Day) => LevelText.text = "DAY : "+Day+"!";
   
}
