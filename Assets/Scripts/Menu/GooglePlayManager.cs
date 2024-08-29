using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class GooglePlayManager : MonoBehaviour
{
    public static GooglePlayManager Instance;

    public void Start()
    {
        SingIn();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
        UnlockAchievemt(GPGSIds.achievement_first_time_jumper);
    }

    public void SingIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            // Continue with Play Games Services
            Debug.Log($"{nameof(GooglePlayManager)} : Sing in Success");
        }
        else
        {
            // Disable your integration with Play Games Services or show a login button
            // to ask users to sign-in. Clicking it should call
            // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
            Debug.Log($"{nameof(GooglePlayManager)} : Sing in Failed");
        }
    }

    #region ACHIEVEMENTS

    public static void UnlockAchievemt(string id)
    {
        PlayGamesPlatform.Instance.ReportProgress(id, 100, success => { });
    }

    public static void ShowAchievementsUI()
    {
        PlayGamesPlatform.Instance.ShowAchievementsUI();
    }

    #endregion
}