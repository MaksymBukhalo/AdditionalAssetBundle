using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class BottonsController : MonoBehaviour
{
    public AudioSource playMyMusic;

    [SerializeField] private Button startLoadAssetBundles;
    [SerializeField] private Button spawnAssetBundles;
    [SerializeField] private Button destroyAssetBundles;
    [SerializeField] private Button playMusic;
    [SerializeField] private Button stopMusic;
    private AssetBundle myAssetBundle;
    private string musicName = "guard.mp3";
    private string sphereName = "Sphere";
    private UnityEngine.Object gamobject;
    private string bundleName = "objectandmusic";

    private void Awake()
    {
        startLoadAssetBundles.onClick.AddListener(StartLoadAssetBundles);
        spawnAssetBundles.onClick.AddListener(SpawnLoadAssetBundles);
        destroyAssetBundles.onClick.AddListener(DestroyAssetBundles);
        playMusic.onClick.AddListener(StartPlayMusic);
        stopMusic.onClick.AddListener(StopPlayMusic);
    }

    private void StopPlayMusic()
    {
        playMyMusic.Stop();
    }

    private void StartPlayMusic()
    {
        playMyMusic.Play();
    }

    private void StartLoadAssetBundles()
    {
        StartCoroutine(Go());
    }

    private void SpawnLoadAssetBundles()
    {
        if (GameObject.Find(sphereName + "(Clone)"))
        {
            Debug.Log("your sphere has already been created");
        }
        else
        {
            Instantiate(gamobject);
        }
    }

    private void DestroyAssetBundles()
    {
        Destroy(GameObject.Find(sphereName + "(Clone)"));
    }

    IEnumerator Go()
    {
        using (WWW send = WWW.LoadFromCacheOrDownload(@"AssetBundles/content/" + bundleName, 0))
        {

            yield return send;

            if (!string.IsNullOrEmpty(send.error))
            {
                Debug.Log(send.error);
                yield break;
            }
            myAssetBundle = send.assetBundle;
            Debug.Log("Bundles загружен");
            gamobject = myAssetBundle.LoadAsset(sphereName);
            Debug.Log("Object");
            var music = myAssetBundle.LoadAssetAsync(musicName, typeof(AudioClip));
            playMyMusic.clip = music.asset as AudioClip;
            Debug.Log("Music");
        }
    }
}
