using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class NowTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayTime;

    private IEnumerator Start()
    {
        while (true)
        {
            displayTime.text = GetCurrntTime();
            yield return new WaitForSeconds(1f);
        }
    }

    public static string GetCurrntTime()
    {
        return DateTime.Now.ToString(("HH : mm"));
    }
}