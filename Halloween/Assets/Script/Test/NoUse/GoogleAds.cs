#if UNITY_ANDROID

using GoogleMobileAds.Api;
using System;
using TMPro;
using UnityEngine;

public class GoogleAds : Singleton<GoogleAds>
{
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    string _adUnitIdTest = "ca-app-pub-3940256099942544/4411468910";//テスト

    readonly string _adUnitIdBanner = "ca-app-pub-3010359569346411/7714719042";//本番ID
    readonly string _adUnitIdInterstitial = "ca-app-pub-3010359569346411/2422917812";//本番ID
    readonly string _adUnitIdReward = "ca-app-pub-3010359569346411/8413611095";//本番ID
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
  private string _adUnitId = "unused";
#endif

    InterstitialAd interstitialAd;

    BannerView bannerView;

    RewardedAd rewardedAd;


    bool isInit = false;
    public void StartInit()
    {
        //DontDestroyOnLoad(this);
        isInit = true;

        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        // Initialize the Google Mobile Ads SDK.　広告の初期化
        MobileAds.Initialize(initStatus =>
        {
            //Init();
            LoadInterstitialAd();

            LoadRewardedAd();
        });


    }

    public void Init()
    {
        if (!isInit)
        {
            Debug.Log("弾かれた広告読み込み");

            throw new System.Exception("広告の読み込み失敗");
            //return;
        }

        //RequestBanner(AdPosition.Top);
        //LoadInterstitialAd();

        //LoadRewardedAd();

    }

    #region  インタースティシャル広告

    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {

        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }


        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        //interstitialAd.CanShowAd += () => { HandleRewardBasedVideoLoaded(); };

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitIdTest, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
                //InterstitialShowAd();
            });

        RegisterReloadHandler(interstitialAd);
    }

    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void InterstitialShowAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            //GameObject.Find("DebugText").GetComponent<TextMeshProUGUI>().text = "ss";
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else
        {
            //GameObject.Find("DebugText").GetComponent<TextMeshProUGUI>().text = "dd";
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    private void RegisterEventHandlers(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    private void RegisterReloadHandler(InterstitialAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
    }

    #endregion

    #region バナー広告

    void CreateBannerView(AdPosition adPos)
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (bannerView != null)
        {
            DestroyAd();
        }

        //_adUnitIdTest
        bannerView = new BannerView
            (_adUnitIdBanner, AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth), adPos);


    }

    public void RequestBanner(AdPosition adPos)
    {

        //_adUnitIdTest
        if (bannerView == null)
        {
            CreateBannerView(adPos);
        }

        //bannerView.OnBannerAdLoaded += () => { HandleRewardBasedVideoLoaded(); };

        //リクエストを生成
        //AdRequest request = new AdRequest.Builder().Build();

        AdRequest request = new();
        //request.Keywords.Add("unity-admob-sample");


        // Load the banner with the request.
        bannerView.LoadAd(request);
        //bannerView.Show();
    }

    /// <summary>
    /// Destroys the ad.
    /// </summary>
    void DestroyAd()
    {
        if (bannerView != null)
        {
            Debug.Log("Destroying banner ad.");
            bannerView.Destroy();
            bannerView = null;
        }
    }

    //public void HandleRewardBasedVideoLoaded()
    //{
    //    bannerView.Show();
    //}

    #endregion

    #region  リワード広告


    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // send the request to load the ad.
        RewardedAd.Load(_adUnitIdTest, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                rewardedAd = ad;
            });

        RegisterReloadHandler(rewardedAd);
    }

    public void ShowRewardedAd()
    {
        const string rewardMsg =
            "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                Debug.Log(String.Format(rewardMsg, reward.Type, reward.Amount));
            });
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    private void RegisterReloadHandler(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
    {
        Debug.Log("Rewarded Ad full screen content closed.");

        // Reload the ad so that we can show another as soon as possible.
        LoadRewardedAd();
    };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAd();
        };
    }

    #endregion


}
#endif