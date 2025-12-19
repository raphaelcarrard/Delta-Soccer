using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;

    private string adUnitId;

    private void Awake()
    {
        #if UNITY_IOS
        adUnitId = iosAdUnitId;
        #elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
        #endif
    }

    private void Start()
    {
        LoadRewardedAd();
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(adUnitId, this);
    }

    #region Load Callbacks
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Rewarded Ad Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Failed to load Rewarded Ad: {error} - {message}");
    }
    #endregion

    #region Show Callbacks
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Show failed: {error} - {message}");
        LoadRewardedAd();
    }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState completionState)
    {
        if (placementId == adUnitId && completionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Ads Fully Watched");
            ScoreManager.instance.ColetaMoedas(50);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        LoadRewardedAd();
    }
    #endregion
}
