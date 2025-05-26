using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NPCPresentationManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Button acceptButton;
    public Button rejectButton;

    private Queue<NPC_Info> npcQueue = new Queue<NPC_Info>();

    public event Action<NPC_Info> OnNPCAccepted;

    private NPC_Info currentNPC;

    private void Awake()
    {
        if (nameText == null)
            nameText = GameObject.Find("NPCName").GetComponent<Text>();

        if (dialogueText == null)
            dialogueText = GameObject.Find("NPCStory").GetComponent<Text>();

        if (acceptButton == null)
            acceptButton = GameObject.Find("Accept").GetComponent<Button>();

        if (rejectButton == null)
            rejectButton = GameObject.Find("Reject").GetComponent<Button>();
    }

    private void Start()
    {
        acceptButton.onClick.AddListener(OnAcceptClicked);
        rejectButton.onClick.AddListener(OnRejectClicked);
    }

    public void PresentNPCs(List<NPC_Info> npcsToPresent)
    {
        npcQueue.Clear();
        foreach (var npc in npcsToPresent)
            npcQueue.Enqueue(npc);

        ShowNextNPC();
    }

    private void ShowNextNPC()
    {
        if (npcQueue.Count == 0)
        {
            gameObject.SetActive(false); // Hide panel when done
            return;
        }

        currentNPC = npcQueue.Dequeue();

        nameText.text = currentNPC.npcName;
        dialogueText.text = currentNPC.npcBackstory;

        gameObject.SetActive(true);
    }

    private void OnAcceptClicked()
    {
        OnNPCAccepted?.Invoke(currentNPC);
        ShowNextNPC();
    }

    private void OnRejectClicked()
    {
        ShowNextNPC();
    }
}
