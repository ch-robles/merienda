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
    float Mamon;
   
    [SerializeField] TextMeshProUGUI UIsubs;
    [SerializeField] TextMeshProUGUI Goalsubs;
    [SerializeField] GameObject UIobject;
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
        //mamonCounter = GetComponent<MamonCounter>();
        //Mamon = Manager.instance.getMamons();
        subtitle = "Time to deliver these stupid ass mamons...";
        Invoke("DeleteText", 3);
        Debug.Log("[MamonHouseRunning] Mamon House running.");
        // UIsubs.gameObject.SetActive(true);
        // Goalsubs.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Mamon = Manager.instance.getMamons();
        Debug.Log("[MAMON HOUSE] Mamons Get: " + Manager.instance.getMamons());
        UIsubs.text = subtitle;
        goal = "You need to deliver " + Mamon + " mamon(s).";
        Goalsubs.text = goal; 
    }

    private void OnTriggerEnter(Collider other)
    {
        //subtitle = "test";
        Debug.Log("[MAMON HOUSE] Annyeonghaseyo.");
        
        if (other.CompareTag("MamonHouse"))
        {
            subtitle = MamonSuccess[rnd.Next(0, MamonSuccess.Length)];
            Invoke("DeleteText", 3);
            Mamon--;
            MamonCounter.currentMamon += 1;
            Manager.instance.setMamons(Mamon);
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
