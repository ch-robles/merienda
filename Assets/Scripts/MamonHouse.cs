using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MamonHouse : MonoBehaviour
{
    string subtitle;
    [SerializeField] TextMeshProUGUI UIsubs;
    
    // Start is called before the first frame update
    void Start()
    {
        subtitle = "Okay, it's morbin time";
    }

    // Update is called once per frame
    void Update()
    {
        UIsubs.text = subtitle;
        Invoke("DeleteText", 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("MamonHouse"))
        {
            subtitle = "Finally, my mamon is here!";
        }
    }

    void DeleteText()
    {
        subtitle = "";
    }
}
