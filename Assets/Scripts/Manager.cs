using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Manager : MonoBehaviour
{
    public static Manager instance;
    [SerializeField] float Mamons;
    public static bool GameIsPaused = false;
    // [SerializeField] Animator transitionAnim;
    int level = 1;
    bool running = true;
    [SerializeField] AggroLevel aggro;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        ButtonClick();
        Debug.Log("Paused");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        ButtonClick();
        Debug.Log("Resumed");
    }


    //----------------------------//

    public void ButtonClick()
    {
        AudioManager.instance.ButtonClick();
        Debug.Log("ButtonClick");
    }

    public void Death()
    {
        AudioManager.instance.Death();
        Pause();
        Debug.Log("Death");

    }

    public void Win()
    {
        AudioManager.instance.Win();
        Pause();
        Debug.Log("Win");
    }

    public void Draw()
    {
        AudioManager.instance.Win();
        Pause();
        Debug.Log("Draw");
    }


    // testing purp

    public int GetLevelNow(){
        return level;
    }

    public bool RunningBa(){
        return running;
    }

    public void VillageAbove(){
        aggro.StartLevel();
    }

    public void ForestBelow(){
        aggro.ChaseScene();
    }

    //----------------------------//

    public void GoToMain()
    {
        Resume();
        SceneManager.LoadSceneAsync(0);
        Debug.Log("GoToMain");
        AudioManager.PlayMenuMusic();
    }

    public void QuitGame()
    {
        ButtonClick();
        Application.Quit();
        Debug.Log("Quit");
    }



    public void Restart()
    {
        Destroy(gameObject);
        instance = null;
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // OnRaceStart();
        Debug.Log("Restart");
    }

    public float getMamons()
    {
        return (Mamons);
    }

    // IEnumerator Chase(){
    //     // // play animations here

    //     Debug.Log("Game Mode: Chase");

    //     transitionAnim.SetTrigger("End");
    //     yield return WaitForSeconds(10);
    //     SceneManager.LoadScene("HuntingGrounds");
    //     transitionAnim.SetTrigger("Start");
        
    // }

    /*public void StartGame()
    {
        Destroy(gameObject);
        instance = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        LevelStart();
        Resume();
        Debug.Log("StartGame");
    }*/

    //----------------------------//

    
    //----------------------------//

    /*
    public GameStates GetMazeState()
    {
        return mazeState;
    }

    public void SetMazeState(GameStates _mazeState)
    {
        mazeState = _mazeState;
    }

    */
    

}
