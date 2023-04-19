using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class BannerAd : MonoBehaviour
{
    Button hideBannerButton;

    BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

    string AndroidAdUnit = "Banner_Android";
    string IOSAdUnit = "Banner_iOS";
    string adUnitID;

    void Awake()
    {
        adUnitID = AndroidAdUnit;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            adUnitID = IOSAdUnit;
        }

        if (hideBannerButton != null)
        {
            hideBannerButton.interactable = false;
        }

        Advertisement.Banner.SetPosition(bannerPosition);
    }

    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        { 
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };
    }

    private void OnBannerLoaded()
    {
        hideBannerButton.onClick.AddListener(HideBannerAd);

        hideBannerButton.interactable = true;
        ShowBannerAd();
    }

    private void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    private void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        Advertisement.Banner.Show(adUnitID, options);
    }

    private void OnBannerClicked()
    {

    }

    private void OnBannerHidden()
    {
        hideBannerButton.interactable = false;
    }

    private void OnBannerShown()
    {
        hideBannerButton.interactable = true;
    }

    private void OnBannerError(string message)
    {
        Debug.Log(message);
    }

    private void OnDestroy()
    {
        if (hideBannerButton != null)
        {
            hideBannerButton.onClick.RemoveAllListeners();
        }
    }
}
