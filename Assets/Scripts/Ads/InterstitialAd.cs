using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    string AndroidAdUnit = "Interstitial_Android";
    string IOSAdUnit = "Interstitial_iOS";
    string adUnitID;

    #region IUnityAdsLoadListener
    public void OnUnityAdsAdLoaded(string placementId)
    {
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region IUnityAdsShowListener
    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    void Awake()
    {
        adUnitID = AndroidAdUnit;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            adUnitID = IOSAdUnit;
        }
    }

    public void LoadAd()
    {
        Advertisement.Load(adUnitID, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(adUnitID, this);
    }
}
