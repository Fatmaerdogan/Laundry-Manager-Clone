using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionUIObject : MonoBehaviour
{
    public Image clotheImage;
    public ClothType clotheType;
    public ColorType colorType;
    public Sprite[] clotheSprite;
    public void Creat(Mission mission)
    {
        clotheImage.sprite = clotheSprite[(int)mission.clothType];
        clotheImage.color = mission.color; 
        clotheType= mission.clothType;
        colorType = mission.ColorType;
    }
}
