using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamonCounter : MonoBehaviour
{
    public static int currentMamon = 0;
    public int test;
    [SerializeField] public int goalMamon = 0;
    public GameObject winUI;
    public GameObject overlay;
    bool levelCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        test = currentMamon;
    }

    // Update is called once per frame
    void Update()
    {
        if ((currentMamon == goalMamon) && !levelCompleted)
        {
            Manager.instance.Pause();
            overlay.SetActive(false)
;            winUI.SetActive(true);
            currentMamon = 0;
            goalMamon = 0;
            levelCompleted = true;
        }
    }
}
