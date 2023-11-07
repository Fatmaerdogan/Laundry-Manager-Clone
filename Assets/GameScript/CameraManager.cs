using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class CameraManager : MonoBehaviour
{
   public void SwitchOtherArea(bool temp)
    {
        if (temp) { transform.DOMoveX(2, 0.1f); }
        else { transform.DOMoveX(-2, 0.1f); }
    }
}
