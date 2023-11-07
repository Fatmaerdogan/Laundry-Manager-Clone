using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPanel : MonoBehaviour
{
    [Header("Mission")]
    public MissionUIObject missionUiObjectPrefab;
    public MissionData MissionData;
    List<MissionUIObject> MissionUIList = new List<MissionUIObject>();

    void Start()
    {
        Events.ClothTakenCareAction += MissionControl;
        MissionStartCreat();
    }

    public void MissionStartCreat()
    {
        foreach (var item in MissionData.Mission_List)
        {
                MissionUIObject mission = Instantiate(missionUiObjectPrefab, transform);
                mission.Creat(item);
                MissionUIList.Add(mission);
                if (item.TakenCare)mission.gameObject.SetActive(false);
        }
    }
    public void MissionControl(Cloth cloth)
    {
        for (int i = 0; i < MissionData.Mission_List.Length; i++)
        {
            if (cloth.ColorType == MissionData.Mission_List[i].ColorType && cloth.type == MissionData.Mission_List[i].clothType && !MissionData.Mission_List[i].TakenCare)
            {
                MissionData.Mission_List[i].TakenCare = true;
                MissionUIList[i].gameObject.SetActive(false);
                break;
            }
        }
    }
}
