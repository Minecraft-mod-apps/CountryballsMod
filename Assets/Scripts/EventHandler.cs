using UnityEngine.Events;

public class EventHandler
{
    public static UnityEvent<int> SetIndexEvent = new UnityEvent<int>();
    public static UnityEvent<string> SetLoadScreenName = new UnityEvent<string>();
    public static UnityEvent StartLoadFile = new UnityEvent();
    public static UnityEvent EndLoadFile = new UnityEvent();
    public static UnityEvent EnableNextScreen = new UnityEvent();
    public static UnityEvent EnablePrevScreen = new UnityEvent();
    public static UnityEvent CloseLoadScreen = new UnityEvent();
    public static UnityEvent OpenFileEvent = new UnityEvent();
    public static UnityEvent AdIsShow = new UnityEvent();
    public static UnityEvent OpenAdIsFailed = new UnityEvent();
    public static UnityEvent LoadingIsEnd = new UnityEvent();
    public static UnityEvent LoadEndNative = new UnityEvent();
    public static UnityEvent ReturnToStart = new UnityEvent();
    public static UnityEvent ShowInterAd = new UnityEvent();
    public static UnityEvent ShowRewardedAd = new UnityEvent();
}