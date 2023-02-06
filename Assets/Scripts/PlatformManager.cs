using UnityEngine;
using Chimpvine.WebClient;

public enum PLATFORM { WEB_PHONE, WEB_PC }

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance;

    public  GameObject loadingPanel;

    public bool Initialized { get; private set; }
    
    public string path;

    public PLATFORM CurrentPlatform { get; private set; } = PLATFORM.WEB_PC;

    private void OnEnable()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;

        
        ChimpvineMessenger.assetsPathInitialized += OnInitialize;

        //#if UNITY_WEBGL && !UNITY_EDITOR
        //        if (ChimpvineWebPlugin.IsMobileBrowser())
        //        {
        //            CurrentPlatform = PLATFORM.WEB_PHONE;
        //        }
        //        else
        //        {
        //            CurrentPlatform = PLATFORM.WEB_PC;
        //        }
        //#elif UNITY_EDITOR || UNITY_STANDALONE
        //        CurrentPlatform = PLATFORM.WEB_PC;
        //#endif
    }

    private void OnInitialize(string path)
    {
        if (Initialized)
        {
            return;
        }

        loadingPanel.SetActive(false);
        this.path = path;
        Initialized = true;

    }

    private void OnDestroy()
    {
        ChimpvineMessenger.assetsPathInitialized -= OnInitialize;
    }
}
