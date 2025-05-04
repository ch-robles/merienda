using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MamonHouse : MonoBehaviour
{
    string subtitle;
    string goal;
    [SerializeField] Manager manager;
    int Mamon;
    [SerializeField] TextMeshProUGUI UIsubs;
    [SerializeField] TextMeshProUGUI Goalsubs;
    System.Random rnd = new System.Random();
    string[] MamonSuccess =
    {
        "Finally, you're here",
        "It's already Christmas...",
        "Thought I would die of hunger at this point",
        "Thanks!",
        "I almost thought you were eaten at this point already",
        "The mamon's already cold bruh",
        "Didn't think I'd be able to eat before the day ends"
    };
    string[] NoMamon =
    {
        "Who the hell wants your mamon?!",
        "Didn't order no mamon",
        "Get away!!",
        "You won't fool me."
    };
    
    // Start is called before the first frame update
    void Start()
    {
        subtitle = "What the hell was that...";
        Invoke("DeleteText", 3);
        goal = "You need to deliver " + Mamon + " mamon(s).";
        
    }

    // Update is called once per frame
    void Update()
    {
        UIsubs.text = subtitle;
        Goalsubs.text = goal;
    }

    private void OnTriggerEnter(Collider other)
    {
        //subtitle = "test";
        
        if (other.CompareTag("MamonHouse"))
        {
            subtitle = MamonSuccess[rnd.Next(0, MamonSuccess.Length)];
            Invoke("DeleteText", 3);
            Mamon--;
            goal = Mamon + " Mamon(s) left to deliver.";
            Destroy(other);
        }

        if (other.CompareTag("NoMamonHouse"))
        {
            subtitle = NoMamon[rnd.Next(0, NoMamon.Length)];
            Invoke("DeleteText", 3);
        }
    }

    void DeleteText()
    {
        subtitle = "";
    }
}
