using UnityEngine;
using UnityEngine.Events;

public class EventHandler
{
    public static UnityEvent<GameObject> GetPrevScreen = new UnityEvent<GameObject>();
    public static UnityEvent StartModInstall = new UnityEvent();
    public static UnityEvent ModInstallComplete = new UnityEvent();
    public static UnityEvent AdIsShowing = new UnityEvent();
    public static UnityEvent LoadEndNative = new UnityEvent();
    public static UnityEvent LoadingEnd = new UnityEvent();
    public static UnityEvent ShowInter = new UnityEvent();
    public static UnityEvent ShowRewarded = new UnityEvent();
}
