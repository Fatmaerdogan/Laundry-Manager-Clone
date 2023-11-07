using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class ClothManager : MonoBehaviour
{
    public Transform SpawnPos;
    List<Cloth> Cloths=new List<Cloth>();
    void Start()
    {
        Events.ClothPlantedAction += ClothSpawn;
        Events.ClothPaintAction += ClothRemove;
    }
    private void OnDestroy()
    {
        Events.ClothPlantedAction -= ClothSpawn;
        Events.ClothPaintAction -= ClothRemove;
    }
    public void ClothSpawn(Cloth cloth)
    {
        Cloths.Add(cloth);
        cloth.transform.DOMove(SpawnPos.position, 1f).OnComplete(() =>
        {
            Resequencing();
        });
    }
    public void ClothRemove(Cloth cloth)
    {
        for (int i=0;i< Cloths.Count;i++)
        {
            if (Cloths[i] == cloth)
            {
                Cloths.RemoveAt(i);
            }
        }
    }
    public void Resequencing()
    {
        Vector3 Pos = SpawnPos.position;
        for (int i = 0; i < Cloths.Count; i++)
        {
            if (Cloths[i].transform.position != Pos)
            {
                Cloths[i].transform.position = Pos;
            }
            Pos += Vector3.right;
        }
     
    }
}
