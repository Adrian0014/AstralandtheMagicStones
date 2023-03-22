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
    [SerializeField] private GameObject camaraNPC;
    [SerializeField] private float unScaledTime;
    [SerializeField, TextArea(4,6)]private string[] dialogueLines;
   

    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;

    private Animator animNPC;
    /*enum State
    {
        Talking1,
        Talking2,
    }
    State currentState;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        currentState = State.Talking1;

    }
    
    void Update()
    {
        switch(currentState)
        {
            case State.Talking1:
                Talk1();
            break;

            case State.Talking2:
                Talk2();
            break;
            
        }
        
        
    }

    void Talk1()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Talk1");
            currentState = State.Talking2;
        }


    }
    void Talk2()
    {
        Debug.Log("Talk2");
    animNPC.SetBool("Charla", true);
        
    }*/
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
        //Debug.Log("Interact!");
        //StartDialogue();
        //FindObjectOfType<ControlDialogos>().ActivarCartel(texto);
        
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        camaraNPC.SetActive(true);
        lineIndex = 0;
        //Global.PlayerScript = true;
        animNPC.SetBool("Charla", true);
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

    /*
        private void TimeChat()
        {
        unScaledTime = Time.fixedUnscaledDeltaTime;
        }    
     */

}
