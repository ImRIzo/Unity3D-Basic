using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

public class AssetDownloader1 : MonoBehaviour
{
    public string bundleName; // Name of the asset bundle file in StreamingAssets
    public string[] assetNames; // Names of the assets to load


    public void LoadAssets(string name)
    {
        StartCoroutine("DownloadAsset",name);
    }
    IEnumerator DownloadAsset(string name)
    {
        string bundlePath = Path.Combine(Application.streamingAssetsPath, bundleName);

        UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle(bundlePath);

        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error loading AssetBundle: " + webRequest.error);
            yield break;
        }

        AssetBundle remoteAssetBundle = DownloadHandlerAssetBundle.GetContent(webRequest);

        if (remoteAssetBundle == null)
        {
            Debug.LogError("Failed to load AssetBundle!");
            yield break;
        }


            Object loadedAsset = remoteAssetBundle.LoadAsset(name);
            if (loadedAsset != null)
            {
                Instantiate(loadedAsset);
            }
            else
            {
                Debug.LogError("Failed to load asset: " + name);
            }


        remoteAssetBundle.Unload(false);
    }
}
