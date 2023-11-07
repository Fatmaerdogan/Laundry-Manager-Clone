
using System;

public class Events
{
    public static Action<int> MoneyChangeAction;
    public static Action<int> LevelChangeAction;
    public static Action<int> LevelIncreasedChangeAction;
    public static Action<Boiler> BoilerSelectAction;
    public static Action<SewingMachine> SewingMachineSelectAction;
    public static Action<Rope> RopeSelectAction;
    public static Action<Cloth> ClothSelectAction;
    public static Action<Cloth> ClothPlantedAction;
    public static Action<Cloth> ClothPaintAction;
    public static Action<Cloth> ClothTakenCareAction;
    

}
[System.Serializable]
public enum ClothType
{
    Sock=0,
    Bra=1,
    Slip=2,
    Short=3
}
[System.Serializable]
public enum ColorType
{
    Red=0,Green=2,Blue=3,Yellow=4
}
