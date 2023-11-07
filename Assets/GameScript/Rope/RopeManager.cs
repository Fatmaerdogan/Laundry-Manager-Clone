using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public Rope RopePrefab;
    public float TimeToProduceRope;
    public Transform[] ProduceLocations;
    void Start()
    {
        StartCoroutine(RopeCreator());
    }
    public IEnumerator RopeCreator()
    {
        foreach (var item in ProduceLocations)
        {
            if (item.childCount== 0)
            {
                Rope rope = Instantiate(RopePrefab, item);
                rope.transform.localPosition = Vector3.zero;
                break;
            }
        }
        yield return new WaitForSeconds(TimeToProduceRope);
        StartCoroutine(RopeCreator());
    }
}
