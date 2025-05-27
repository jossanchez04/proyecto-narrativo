using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class NPCPresentationManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image avatarImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Button acceptButton;
    public Button rejectButton;

    private Queue<NPC_Info> npcQueue = new Queue<NPC_Info>();

    public event Action<NPC_Info> OnNPCAccepted;

    private NPC_Info currentNPC;

    public event Action OnPresentationComplete;


    private void Start()
    {
        acceptButton.onClick.AddListener(OnAcceptClicked);
        rejectButton.onClick.AddListener(OnRejectClicked);
    }

    public void PresentNPCs(List<NPC_Info> npcsToPresent)
    {
        Debug.Log("PresentNPCs called, activating panel");
        gameObject.SetActive(true);
        npcQueue.Clear();
        foreach (var npc in npcsToPresent)
            npcQueue.Enqueue(npc);

        ShowNextNPC();
    }

    private void ShowNextNPC()
    {
        if (npcQueue.Count == 0)
        {
            Debug.Log("All NPCs presented, hiding panel");
            gameObject.SetActive(false); // Hide panel when done
            OnPresentationComplete?.Invoke();
            return;
        }

        currentNPC = npcQueue.Dequeue();

        if (nameText != null)
        {
            Debug.Log($"Setting name text: {currentNPC?.npcName ?? "No Name"}");
            nameText.text = currentNPC?.npcName ?? "No Name";
        }

        if (dialogueText != null)
        {
            Debug.Log($"Setting dialogue text: {currentNPC?.npcBackstory ?? "No Story"}");
            dialogueText.text = currentNPC?.npcBackstory ?? "No Story";
        }

        if (avatarImage != null)
        {
            Debug.Log($"Setting avatar image sprite: {(currentNPC?.avatarSprite != null ? currentNPC.avatarSprite.name : "null")}");
            avatarImage.sprite = currentNPC?.avatarSprite;
        }

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
