using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Advertisements;

[RequireComponent(typeof(RewardAd), typeof(InterstitialAd), typeof(BannerAd))]
public class AdManager : MonoBehaviour, IUnityAdsInitializationListener
{
    public string AndroiGameID;
    public string IOSGameID;
    public bool testMode;

    private InterstitialAd interstitialAd;
    public InterstitialAd InterstitialAd => interstitialAd;

    private BannerAd bannerAd;
    public BannerAd BannerAd => bannerAd;
    
    private RewardAd rewardAd;
    public RewardAd RewardAd => rewardAd;

    #region IUnityAdsInitializationListener
    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    void Awake()
    {
        interstitialAd = GetComponent<InterstitialAd>();
        bannerAd = GetComponent<BannerAd>();
        rewardAd = GetComponent<RewardAd>();

        string gameID = AndroiGameID;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            gameID = IOSGameID;
        }

        if (string.IsNullOrEmpty(gameID))
        {
            throw new InvalidDataException("There is no game ID currently set, Please ensure game ID is set properly.");
        }

        Advertisement.Initialize(gameID, testMode, this);
    }
}
