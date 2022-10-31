using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image bar;

    public void UpdateHP(float ratio)
    {
        StartCoroutine(ChangeHP(ratio, ratio < bar.fillAmount));
    }

    IEnumerator ChangeHP(float target, bool isReducing)
    {
        if (isReducing)
        {
            while (bar.fillAmount > target)
            {
                bar.fillAmount -= 0.01f;
                yield return new WaitForEndOfFrame();
            }
            bar.fillAmount = target;
        } else
        {
            while (bar.fillAmount < target)
            {
                bar.fillAmount += 0.01f;
                yield return new WaitForEndOfFrame();
            }
            bar.fillAmount = target;
        }
    }
}
