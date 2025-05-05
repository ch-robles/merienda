using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Manager : MonoBehaviour
{
    public static Manager instance;
    // [SerializeField] float Mamons;
    float mamons = 0.0f;
    public static bool GameIsPaused = false;
    // [SerializeField] Animator transitionAnim;
    int level = 1;
    bool running = true;
    bool start = false;
    [SerializeField] AggroLevel aggro;
    Vector3 checkpoint;

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
        Debug.Log("[MANAGER] Mamons Now: " + mamons);
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
        Debug.Log("[MANAGER] Resumed");
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



    // testing purp

    public int GetLevelNow(){
        return level;
    }

    public bool RunningBa(){
        return running;
    }

    // public void RunningLevel(){
    //     start = true;
    // }

    // public void EndingLevel(){
    //     start = false;
    // }

    public bool GetState(){
        return start;
    }

    public void SetState(bool startBool){
        start = startBool; 
    }

    public void SetLevel(int levelNo){
        level = levelNo; 
    }

    public int GetLevel(){
        return level;
    }

    public void VillageAbove(){
        aggro.StartLevel();
        AudioManager.PlayGameMusic();
        AggroLevel.instance.StartLevel();
    }

    public void ForestBelow(){
        AggroLevel.instance.ChaseScene();
        SceneTransition.instance.Chase();
    }

    public void SetCheckpoint(Vector3 checkpointPos){
        checkpoint = checkpointPos;
        Debug.Log("New checkpoint!");
    }

    

    public Vector3 GetCheckpoint(){
        if(start){
            return checkpoint;
        } else {
            switch(level){
                case 1:
                    Debug.Log("In Level 1");
                    checkpoint = new Vector3(224.55f,19.022f,222.74f);
                    return checkpoint;
                    break;
                case 2:
                    Debug.Log("In Level 2");
                    checkpoint = new Vector3(0,0,0);
                    return checkpoint;
                    break;
                case 3: 
                    Debug.Log("In Level 3");
                    checkpoint = new Vector3(0,0,0);
                    return checkpoint;
                    break;
            }
        }

        Vector3 defaultPos = new Vector3(0f,0f,0f);
        return defaultPos;
        
    }

    //----------------------------//

    public void GoToMain()
    {
        //Resume();
        SceneManager.LoadSceneAsync(0);
        Debug.Log("GoToMain");
        AudioManager.PlayMenuMusic();
    }

    public void GoToTutorial()
    {
        Resume();
        SceneManager.LoadSceneAsync(1);
        Debug.Log("GoToTutorial");
        AudioManager.PlayGameMusic();
    }

    public void GoToLvl1()
    {
        Resume();
        SceneManager.LoadSceneAsync(2);
        Debug.Log("GoToLVL1");
        AudioManager.PlayGameMusic();
    }

    public void GoToLvl2()
    {
        Resume();
        SceneManager.LoadSceneAsync(3);
        Debug.Log("GoToLVL2");
        AudioManager.PlayGameMusic();
    }

    public void GoToLvl3()
    {
        Resume();
        SceneManager.LoadSceneAsync(4);
        Debug.Log("GoToLVL3");
        AudioManager.PlayGameMusic();
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
        return mamons;
    }

    public void setMamons(float mamonsGet)
    {
        mamons = mamonsGet;
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
