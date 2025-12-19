using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class AchievementManager : MonoBehaviour
{
    
    public static AchievementManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CheckAchievements()
    {
        if(OndeEstou.instance.fase == 8)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievementLevel5, 100f, (bool success) => { });
        }
        if(OndeEstou.instance.fase == 13)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievementLevel10, 100f, (bool success) => { });
        }
        if(OndeEstou.instance.fase == 17)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievementLevel14, 100f, (bool success) => { });
        }
        if(OndeEstou.instance.fase == 21)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievementLevel18, 100f, (bool success) => { });
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievementGameCompleted, 100f, (bool success) => { });
        }
    }
}
