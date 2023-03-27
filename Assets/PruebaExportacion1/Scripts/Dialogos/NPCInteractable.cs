using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class NPCInteractable : MonoBehaviour
{
    //public Textos texto;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text nameText; 
    [SerializeField] private GameObject camaraNPC;
    [SerializeField] private float unScaledTime;
    [SerializeField, TextArea(4,6)]private string[] dialogueLines;
    [SerializeField, TextArea(4,6)]private string[] nameLines;
   

    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;

    private Animator animNPC;

    void Awake()
    {
        animNPC = GetComponent<Animator>();
    }
    public void Interact()
    {
        Debug.Log("Interact!");
        if(!didDialogueStart)
        {
           StartDialogue(); 
        }
        else if(dialogueText.text == dialogueLines[lineIndex])
        {
            NextDialogueLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        camaraNPC.SetActive(true);
        lineIndex = 0;
        animNPC.SetBool("Charla", true);
        nameText.text = nameLines[lineIndex];
        Time.timeScale = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            camaraNPC.SetActive(false);
            Global.PlayerScript = false;
            animNPC.SetBool("Charla", false);
            Time.timeScale = 1;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    public void EntrarCasa1()
    {
        Debug.Log("Entrar a casa");
        SceneManager.LoadScene(1);
    }
}
