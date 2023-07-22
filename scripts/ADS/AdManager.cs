using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener
{

    [SerializeField] string _androidGameId = "5332214";
    [SerializeField] string _iOSGameId = "5332215";
    [SerializeField] bool _testMode = true;
    private string _gameId;
 
    void Awake()
    {
        InitializeAds();
    }
 
    public void InitializeAds()
    {
    #if UNITY_IOS
            _gameId = _iOSGameId;
    #elif UNITY_ANDROID
            _gameId = _androidGameId;
    #elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
    #endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

 
    public void OnInitializationComplete()
    {
        #if UNITY_EDITOR
             Debug.Log("Unity Ads initialization complete.");
         #endif
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        #if UNITY_EDITOR
             Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
         #endif
    }




}
  
