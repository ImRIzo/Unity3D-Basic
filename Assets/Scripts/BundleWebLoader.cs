using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BundleWebLoader : MonoBehaviour
{
    [SerializeField] string bundleUrl = "http://localhost/assetbundles/group1";    
    [SerializeField] List<string> assetNames = new List<string>();
    // Start is called before the first frame update
    IEnumerator DownloadAsset()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null)
            {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }
            
            foreach(string name in assetNames)
            {
                Instantiate(remoteAssetBundle.LoadAsset(name));
            }
            
            remoteAssetBundle.Unload(false);            
        }
    }

    public void LoadAssets()
    {
        StartCoroutine(nameof(DownloadAsset));
    }

}