using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public float counter = 1;
    public AudioSource dialogueSound;
    public AudioClip Dialogue1;
    public AudioClip Dialogue2;
    public AudioClip Dialogue3;
    public AudioClip Dialogue4;

    public Text nameText;
    public Text DialogueText;
    public Animator doorAnim;
    public Animator animator;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue (Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (counter == 1)
        {
            dialogueSound.clip = Dialogue1;
            dialogueSound.Play();
        }
        if (counter == 2)
        {
            dialogueSound.clip = Dialogue2;
            dialogueSound.Play();

        }
        if (counter == 3)
        {
            dialogueSound.clip = Dialogue3;
            dialogueSound.Play();
        }
        if (counter == 4)
        {
            dialogueSound.clip = Dialogue4;
            dialogueSound.Play();
        }
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
        counter++;
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
        doorAnim.SetBool("Door", true);
    }
    
}
