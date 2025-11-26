using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{

    public static LoadingManager Instance;
    public GameObject loadingScreenObject;
    public Slider progressBar;
    bool isNoMusicActiveOnce = false;
    bool isLoadingActiveOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    
    public void SwitchToScene(int id)
    {
        //loadingScreenObject.SetActive(true);
        //progressBar.value = 0;
        
        StartCoroutine(SwitchToSceneAsync(id));
    }

    IEnumerator SwitchToSceneAsync(int id)
    {
        isNoMusicActiveOnce = true;

        loadingScreenObject.SetActive(true);
        progressBar.value = 0;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(id);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            progressBar.value = asyncLoad.progress;
            yield return null;
        }

        progressBar.value = 1f;

        yield return new WaitForEndOfFrame();

        // Activate scene
        asyncLoad.allowSceneActivation = true;

        while (!asyncLoad.isDone)
            yield return null;

        loadingScreenObject.SetActive(false);

        if (!loadingScreenObject.activeInHierarchy)
        {
            isLoadingActiveOnce = true;
        }



    }


    // Update is called once per frame
    void Update()
    {
        if (isLoadingActiveOnce && isNoMusicActiveOnce)
        {
            AudioManager.PlayGameMusic();
            Manager.instance.VillageAbove();
            isNoMusicActiveOnce = false;
            isLoadingActiveOnce = false;
        }
        else if (isNoMusicActiveOnce)
        {
            AudioManager.PlayNoMusic();
        }
    }
}
