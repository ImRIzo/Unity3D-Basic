using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BundleWebLoader2 : MonoBehaviour
{
    [SerializeField] string bundleUrl = "http://localhost/assetbundles/group1";
    [SerializeField] List<string> assetNames = new List<string>();
    // Start is called before the first frame update
    IEnumerator DownloadAsset()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(bundleUrl);
        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error downloading AssetBundle: " + webRequest.error);
            yield break;
        }

        AssetBundle remoteAssetBundle = AssetBundle.LoadFromMemory(webRequest.downloadHandler.data);
        
        if (remoteAssetBundle == null)
        {
            Debug.LogError("Failed to download AssetBundle!");
            yield break;
        }

        foreach (string name in assetNames)
        {
            Object loadedAsset = remoteAssetBundle.LoadAsset(name);
            if (loadedAsset != null)
            {
                Instantiate(loadedAsset);
            }
            else
            {
                Debug.LogError("Failed to load asset: " + name);
            }
        }

        remoteAssetBundle.Unload(false);
    }

    public void LoadAssets()
    {
        StartCoroutine(nameof(DownloadAsset));
    }

}