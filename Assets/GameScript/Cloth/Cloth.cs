
using DG.Tweening;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Cloth :MonoBehaviour
{
    public float ProcessingTimer;
    public int IncomeAmount;
    public SpriteRenderer SelectionCircle;
    public ColorType ColorType;
    public ClothType type;

    MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer=GetComponent<MeshRenderer>();
    }
    public virtual void Painting(ColorType colorType, Color color)
    {
        ColorType = colorType;
        SelectionCircle.gameObject.SetActive(false);
        meshRenderer.material.DOColor(color, ProcessingTimer).OnComplete(() => {
            transform.SetParent(null);
            transform.DOMoveY(10, 1);
            transform.DOScale(Vector3.one, 1).OnComplete(() => Destroy(this.gameObject));
            Events.MoneyChangeAction?.Invoke(IncomeAmount);
            Events.LevelChangeAction?.Invoke(1);
            Events.ClothTakenCareAction?.Invoke(this);
        });
    }
  
    public virtual void Sew()
    {
        SelectionCircle.gameObject.SetActive(false);
        transform.DOMoveY(transform.position.y + 0.02f, ProcessingTimer).OnComplete(() =>
        {
            transform.localScale = Vector3.one * 2;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            SelectionCircle.gameObject.SetActive(true);
            Events.ClothPlantedAction?.Invoke(this);
        });
    }
    private void OnMouseEnter()
    {
        SelectionCircle.color = Color.green;
        transform.localScale = Vector3.one * 2.25f;
        transform.localPosition =new Vector3(transform.position.x,-0.7f, transform.position.z);
        Events.ClothSelectAction?.Invoke(this);
    }
    public void NotSelected()
    {
        SelectionCircle.color = Color.white;
        transform.localScale = Vector3.one*2;
        transform.localPosition = new Vector3(transform.position.x, -0.75f, transform.position.z);
    }
}
