// NPCClickHandler.cs
using UnityEngine;

public class NPCClickHandler : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("NPC"))
            {
                NPC_Info npc = hit.collider.GetComponent<NPC_Info>();

                if (npc != null)
                {
                    NPCUIManager.Instance.ShowNPCPopup(npc);
                }
                else
                {
                    Debug.LogWarning("NPC tagged object has no NPC_Info component.");
                }
            }
        }
    }
}
