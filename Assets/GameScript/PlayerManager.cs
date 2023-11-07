using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rope SelectRope;
    public SewingMachine SelectSewingMachine;
    public Boiler SelectBoiler;
    public Cloth SelectCloth;

    private void Start()
    {
        Events.RopeSelectAction += RopeIdentification;
        Events.BoilerSelectAction += BoilerIdentification;
        Events.SewingMachineSelectAction += SewingMachineIdentification;
        Events.ClothSelectAction += ClothIdentification;
    }
    private void OnDestroy()
    {
        Events.RopeSelectAction -= RopeIdentification;
        Events.BoilerSelectAction -= BoilerIdentification;
        Events.SewingMachineSelectAction -= SewingMachineIdentification;
        Events.ClothSelectAction -= ClothIdentification;
    }
    public void BoilerIdentification(Boiler boiler)
    {
        SelectBoiler = boiler;
        if (SelectCloth != null)
        {
            Events.ClothPaintAction?.Invoke(SelectCloth);
            SelectBoiler.Painting(SelectCloth);
            SelectCloth = null;
        }
    }
    public void RopeIdentification(Rope rope)
    {
        if (SelectRope != null) SelectRope.NotSelected();
        SelectRope = rope;
    }
    public void SewingMachineIdentification(SewingMachine sewingMachine)
    {
        SelectSewingMachine = sewingMachine;
        if (SelectRope != null)
        {
            SelectSewingMachine.Planting(SelectRope);
            SelectRope = null;
        }
    }
    public void ClothIdentification(Cloth clothe)
    {
        if (SelectCloth != null) SelectCloth.NotSelected();
        SelectCloth = clothe;
    }
}
