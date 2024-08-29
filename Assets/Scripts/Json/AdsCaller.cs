using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsCaller : MonoBehaviour
{
    public void ShowNonRewardedAd()
    {
        UnityAdsManager.Instance.ShowNonRewardedAd();
    }
}
