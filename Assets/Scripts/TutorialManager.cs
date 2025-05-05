using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class TutorialManager : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public TMP_Text tutorialText;
    //private int tutorialStage = 0;
    public TMP_Text warningText;
    //public RectTransform letterboxTop;
    //public RectTransform letterboxBottom;

    [Header("Settings")]
    private PlayerController controller;
    //private CinemachinePOV pov;

    private enum TutorialStage
    {
        LookAround,
        Move,
        Jump,
        Torch,
        Objective,
        Interact,
        Complete
    }

    private TutorialStage currentStage = TutorialStage.LookAround;
    private string currentText = "";

    [Header("Controls")]
    private bool lookedAround = false;
    private bool moved = false;
    private bool jumped = false;
    private bool torched = false;
    private bool interacted = false;

    void Start()
    {
        // Initialize references
        controller = player.GetComponent<PlayerController>();
        //pov = player.GetComponentInChildren<CinemachinePOV>();
        UpdateTutorialText();
    }

    void Update()
    {
        switch (currentStage)
        {
            case TutorialStage.LookAround:
                if (LookedAround())
                {
                    currentStage = TutorialStage.Move;
                    UpdateTutorialText();
                }
                break;

            case TutorialStage.Move:
                if (Moved())
                {
                    currentStage = TutorialStage.Jump;
                    UpdateTutorialText();
                }
                break;

            case TutorialStage.Jump:
                if (Jumped())
                {
                    currentStage = TutorialStage.Torch;
                    UpdateTutorialText();
                }
                break;

            case TutorialStage.Torch:
                if (Torched())
                {
                    currentStage = TutorialStage.Objective;
                    UpdateTutorialText();
                }
                break;

            case TutorialStage.Objective:
                // Additional logic for objective can be added here
                break;

            case TutorialStage.Interact:
                if (Interacted())
                {
                    currentStage = TutorialStage.Complete;
                    UpdateTutorialText();
                }
                break;

            case TutorialStage.Complete:
                // Tutorial complete
                break;
        }

    }

    private void UpdateTutorialText()
    {
        switch (currentStage)
        {
            case TutorialStage.LookAround:
                currentText = "Use the mouse to look around";
                break;

            case TutorialStage.Move:
                currentText += "\nUse WASD to move";
                break;

            case TutorialStage.Jump:
                currentText += "\nPress the Spacebar to jump";
                break;

            case TutorialStage.Torch:
                currentText += "\nPress F to toggle the Torch";
                break;

            case TutorialStage.Objective:
                currentText += "\nObjective: Follow the dirtpath across to your first delivery";
                break;

            case TutorialStage.Interact:
                currentText += "\nPress E to interact";
                break;

            case TutorialStage.Complete:
                currentText += "\nSkibidi";
                break;
        }

        tutorialText.text = currentText;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder") && currentStage == TutorialStage.Objective)
        {
            currentText += "\nPress E to interact";
        }

        if (other.CompareTag("Boundary"))
        {
            ShowBoundaryWarning();
        }
    }

    bool LookedAround()
    {
        return Mathf.Abs(Input.GetAxis("Mouse X")) > 0.1f || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.1f;
    }

    bool Moved()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }

    bool Jumped()
    {
        return Input.GetKey(KeyCode.Space);
    }

    bool Torched()
    {
        return Input.GetKey(KeyCode.F);
    }

    bool Interacted()
    {
        return Input.GetKey(KeyCode.E);
    }

    

     public void ShowBoundaryWarning()
    {
        StopAllCoroutines(); // stop existing warning
        StartCoroutine(DisplayWarning());
    }

    IEnumerator DisplayWarning()
    {
        warningText.text = "You shouldn't go that way.";
        warningText.enabled = true;
        yield return new WaitForSeconds(3f);
        warningText.enabled = false;
    }
}
