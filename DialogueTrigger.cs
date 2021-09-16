using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public float timeLeft = 2;
    bool popped = false;
    public Dialogue dialogue;
    public void Update()
    {

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0 && popped == false)
        {
            TriggerDialogue();
            popped = true;
           
        }
    }
    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
