using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInstruction : MonoBehaviour
{
    [SerializeField] GameObject previousText;
    [SerializeField] GameObject currentText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger Entered: " + other.name);

            if (other.CompareTag("Player")) // Make sure your player has the "Player" tag
            {
                previousText.SetActive(false);
                currentText.SetActive(true);
            }
        }

    }
}
