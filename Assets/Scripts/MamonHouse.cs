using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MamonHouse : MonoBehaviour
{
    public int currentMamon = 0;
    [SerializeField] public int goalMamon = 0;
    public int finalMamon = 0;
    public GameObject winUi;
    public GameObject UiObject;


    //==============

    string goal;
    string subtitle;

    [SerializeField] TextMeshProUGUI GoalSubs;
    [SerializeField] TextMeshProUGUI UiSubs;

    System.Random rnd = new System.Random();
    string[] MamonSuccess =
    {
        "Finally, you're here",
        "It's already Christmas...",
        "Thought I would die of hunger at this point",
        "Thanks!",
        "I almost thought you were eaten at this point already",
        "The mamon's already cold",
        "Didn't think I'd be able to eat before the day ends"
    };
    string[] NoMamon =
    {
        "Who wants your mamon?!",
        "Didn't order no mamon",
        "Get away!!",
        "You won't fool me."
    };
    
    // Start is called before the first frame update
    void Start()
    {
        //mamonCounter = GetComponent<MamonCounter>();
        //Mamon = Manager.instance.getMamons();
        // UIsubs.gameObject.SetActive(true);
        // Goalsubs.gameObject.SetActive(true);

        finalMamon = goalMamon;

        goal = "You need to deliver " + goalMamon + " mamon(s).";
        GoalSubs.text = goal;

        subtitle = "Time to deliver these mamons...";
        UiSubs.text = subtitle;

        Invoke("DeleteText", 3);
        Debug.Log("[MamonHouseRunning] Mamon House running.");
    }

    // Update is called once per frame
    void Update()
    {
        //UIsubs.text = subtitle;
    }

    private void OnTriggerEnter(Collider other)
    {
        //subtitle = "test";
        Debug.Log("[MAMON HOUSE] Annyeonghaseyo.");
        
        if (other.CompareTag("MamonHouse"))
        {
            currentMamon += 1;
            goalMamon -= 1;

            goal = goalMamon + " Mamon(s) left to deliver.";
            GoalSubs.text = goal;

            subtitle = MamonSuccess[rnd.Next(0, MamonSuccess.Length)];
            UiSubs.text = subtitle;

            Invoke("DeleteText", 3);

            if (currentMamon == finalMamon)
            {
                Manager.instance.Win();
                UiObject.SetActive(false); 
                winUi.SetActive(true);
                currentMamon = 0;
                goalMamon = 0;
                finalMamon = 0;
            }

            Destroy(other);
        }

        if (other.CompareTag("NoMamonHouse"))
        {
            subtitle = NoMamon[rnd.Next(0, NoMamon.Length)];
            UiSubs.text = subtitle;
            Invoke("DeleteText", 3);
            Destroy(other);
        }
    }

    void DeleteText()
    {
        subtitle = "";
        UiSubs.text = subtitle;
    }
}
