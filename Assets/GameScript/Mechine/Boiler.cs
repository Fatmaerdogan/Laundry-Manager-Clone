using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using static System.TimeZoneInfo;

public class Boiler : Machine
{
    [Header("Referance")]
    public Transform RotatReferance;
    public Vector3 RotatReferancePosition;

    [Header("Type")]
    public Color color;
    public ColorType colorType;
    public  override void Start()
    {
        base.Start();
        GetComponent<MeshRenderer>().materials[1].color = color;
    }
    private void Update()
    {
        if(RotatReferance.childCount>0) RotatReferance.Rotate(0, 1, 0);
    }
    public void Painting(Cloth cloth)
    {
        cloth.transform.parent=RotatReferance.transform;
        cloth.transform.localPosition= RotatReferancePosition;
        cloth.transform.localScale = Vector3.one;
        cloth.Painting(colorType,color);
        DurationCircleCompletion(cloth.ProcessingTimer);
    }
    public void OnMouseEnter()
    {
        if (Unlock)
        {
            if (Paid || Paying())
            {
                Events.BoilerSelectAction?.Invoke(this);
            }
        }
    }
}
