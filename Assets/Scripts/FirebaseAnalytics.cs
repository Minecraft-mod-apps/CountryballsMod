using Firebase.Crashlytics;
using UnityEngine;

public class FirebaseAnalytics : MonoBehaviour
{
    void Start () 
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;
                Crashlytics.ReportUncaughtExceptionsAsFatal = true;
            }
        });
    }
}
