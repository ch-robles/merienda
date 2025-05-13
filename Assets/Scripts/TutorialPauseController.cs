using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPauseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Manager.GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Manager.instance.Pause();
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        Manager.instance.Resume();
        pauseMenuUI.SetActive(false);
    }
}
