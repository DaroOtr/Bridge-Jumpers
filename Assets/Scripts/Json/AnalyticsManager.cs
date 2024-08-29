using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;
    async void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            
            await UnityServices.InitializeAsync();
        
            if ( UnityServices.State == ServicesInitializationState.Initialized)
                Debug.Log("ServicesInitializationState.Initialized");
        
            AnalyticsService.Instance.StartDataCollection();

            Debug.Log($"Started UGS Analytics Sample with user ID: {AnalyticsService.Instance.GetAnalyticsUserID()}");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SendTestEvent()
    {
        CustomEvent testCustomEvent = new CustomEvent("test_Custom_Event")
        {
            {"test_Custom_Event","Testing Parameter"}
        };
        AnalyticsService.Instance.RecordEvent(testCustomEvent);
            
        Debug.Log("Recording Test Event");
    }

    public void RecordCrash()
    {
        CustomEvent crashCustomEvent = new CustomEvent("Bridge_Jumpers_CrashReport")
        {
            {"Crash_Report","Game Crash"}
        };
        AnalyticsService.Instance.RecordEvent(crashCustomEvent);
        
        Debug.Log("Recording Crash Event");
    }

    public void RecordPurchaseEvent(string itemName,int itemValue,int itemIndex)
    {
        PurchaseEvent purchase = new PurchaseEvent
        {
           ItemName = itemName,
           ItemValue = itemValue,
           ItemIndex = itemIndex
        };

        AnalyticsService.Instance.RecordEvent(purchase);
        
        Debug.Log("Recording Purchase Event");
        Debug.Log("Item Name : " + itemName);
        Debug.Log("Item Value : " + itemValue);
        Debug.Log("Item Index : " + itemIndex);
    }

    public void RecordHighScoreEvent(int playerHighScore,string characterName)
    {
        HighScoreEvent highScore = new HighScoreEvent
        {
            Score = playerHighScore,
            Character = characterName
        };

        AnalyticsService.Instance.RecordEvent(highScore);
        
        Debug.Log("Recording HighScore Event");
        Debug.Log("Player Score : " + playerHighScore);
        Debug.Log("Character Name : " + characterName);
    }
}
