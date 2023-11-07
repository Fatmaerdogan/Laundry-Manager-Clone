
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public abstract class Machine:MonoBehaviour
{
    [Header("Variable")]
    public int UnlockLevel;
    public int UnlockAmount;
    public bool Unlock,Paid;


    [Header("Outsourced")]
    public GameObject Key;
    public TMP_Text UnlockLevelText;
    public Image DurationCircle;

    [Header("Particle")]
    public ParticleSystem Magicparticle;
    public virtual void Start()
    {
        TempChange();
        Events.LevelIncreasedChangeAction += LevelControl;
    }
    private void OnDestroy()
    {
        Events.LevelIncreasedChangeAction -= LevelControl;
    }

    public virtual void DurationCircleCompletion(float timer)=>DOTween.To(() => DurationCircle.fillAmount, x => DurationCircle.fillAmount = x, 1, timer).OnComplete(() =>
    {
        Magicparticle.Play();
        DurationCircle.fillAmount = 0;
    });
    public virtual void TempChange()
    {
        if (Unlock)
        {
            if (Paid) Key.SetActive(false);
            else UnlockLevelText.text = UnlockAmount + "$";
        }
        else UnlockLevelText.text = "LEVEL\n" + UnlockLevel;
    }
    public virtual bool Paying()
    {
        if (GameManager.instance.OnMoneyEnoughChanged(UnlockAmount))
        {
            Events.MoneyChangeAction?.Invoke(UnlockAmount * -1);
            Paid = true;
            TempChange();
            return true;
        }
        return false;
    }
    public void LevelControl(int Level)
    {
        if (Level>=UnlockLevel)
        {
            Unlock = true;
            TempChange();
        }
    }
}
