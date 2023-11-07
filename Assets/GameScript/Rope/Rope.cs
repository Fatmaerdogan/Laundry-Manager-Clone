using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject[] PieceOfRopeList;
    public SpriteRenderer SelectionCircle;
    public IEnumerator UntieTheRope(float Timer)
    {
        SelectionCircle.gameObject.SetActive(false);
        transform.localScale = Vector3.one*0.75f;
        transform.localPosition = Vector3.zero;
        foreach (var item in PieceOfRopeList)
        {
            item.SetActive(false);
            yield return new WaitForSeconds(Timer / PieceOfRopeList.Length);
        }
        Destroy(this.gameObject);
    }
    private void OnMouseEnter()
    {
        SelectionCircle.color = Color.green;
        transform.GetChild(0).localScale = Vector3.one * 1.5f;
        transform.localPosition = Vector3.up * 0.1f;
        Events.RopeSelectAction?.Invoke(this);
    }
    public void NotSelected()
    {
        SelectionCircle.color = Color.white;
        transform.GetChild(0).localScale = Vector3.one;
        transform.localPosition = Vector3.zero;
    }
}
