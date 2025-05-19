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
        loadingScreenObject.SetActive(true);
        progressBar.value = 0;
        StartCoroutine(SwitchToSceneAsync(id));
    }

    IEnumerator SwitchToSceneAsync(int id)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(id);
        while (!asyncLoad.isDone)
        {
            progressBar.value = asyncLoad.progress;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        loadingScreenObject.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
