using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NpcDialogue : MonoBehaviour
{
    public string[] dialogueNpc;
    public int dialogueIndex;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text nameNpc;
    public Image imageNpc;
    public Sprite spriteNpc;

    public bool readyToSpeak;
    public bool startDialogue;

    private Coroutine typingCoroutine;

    private float previousMoveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && readyToSpeak)
        {
            if(!startDialogue)
            {
                playerLogic player = FindObjectOfType<playerLogic>();
            
                if(player != null)
                {
                previousMoveSpeed = player.moveSpeed;
                player.moveSpeed = 0f;
                }

                StartDialogue();
            }
            else 
            {   if(dialogueText.text == dialogueNpc[dialogueIndex])
                {
                    NextDialogue();
                }
            }
        }
    }
    void NextDialogue()
    {
        dialogueIndex++;

        if(dialogueIndex < dialogueNpc.Length)
        {
            if(typingCoroutine != null) StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine(ShowDialogue());
        }
        else
        {
            CloseDialogue();
        }
    }
    void StartDialogue()
    {
        nameNpc.text = "Bellator";
        imageNpc.sprite = spriteNpc;
        startDialogue = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        
        if(typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(ShowDialogue());
    }
    void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        startDialogue = false;
        dialogueIndex = 0;

        playerLogic player = FindObjectOfType<playerLogic>();
        if(player != null)
        {
            player.moveSpeed = previousMoveSpeed;
        }
    }
    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueNpc[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            readyToSpeak = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            readyToSpeak = false;

            if (startDialogue)
            {
                CloseDialogue();
            }
        }
    }
}
