using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SewingMachine : Machine
{
    [Header("ImageGarment")]

    public Image ImageGarmentSewn;
    public Image ImageGarmentSewnOutside;
    public Color ImageGarmentSewnColor, ImageGarmentSewnOutsideColor;

    [Header("Referance")]
    public Transform Needle;
    public Transform RopeReferancePos;
    public Transform CreatReferancePos;

    [Header("Prefab")]
    public Cloth clothPrefab;

    public void Planting(Rope rope)
    {
        rope.transform.DOMove(RopeReferancePos.position, 0.2f).OnComplete(() =>
        {
            rope.transform.SetParent(RopeReferancePos);
            StartCoroutine(rope.UntieTheRope(clothPrefab.ProcessingTimer));
            Cloth cloth = Instantiate(clothPrefab, CreatReferancePos.transform.position, CreatReferancePos.transform.rotation);
            cloth.Sew();
            UpDownMovementNeedle();
            ImageGarmentSet(cloth.ProcessingTimer);

        });
    }
    public void ImageGarmentSet(float Timer)
    {
        ImageGarmentSewn.DOColor(ImageGarmentSewnColor, Timer);
        ImageGarmentSewnOutside.DOColor(ImageGarmentSewnOutsideColor, Timer).OnComplete(() =>
        {
            ImageGarmentSewn.color = Color.gray;
            ImageGarmentSewnOutside.color = Color.white;
            Magicparticle.Play();
        });
    }
    public void UpDownMovementNeedle()
    {
        if (RopeReferancePos.childCount > 0)
        {
            Needle.DOLocalMoveY(-0.04f, clothPrefab.ProcessingTimer / 100).OnComplete(() =>
            Needle.DOLocalMoveY(0, clothPrefab.ProcessingTimer / 100).OnComplete(() => UpDownMovementNeedle()));
        }

    }
    public void OnMouseEnter()
    {
        if (Unlock)
        {
            if (Paid||Paying())
            {
                Events.SewingMachineSelectAction?.Invoke(this);
            }

        }

    }
}
