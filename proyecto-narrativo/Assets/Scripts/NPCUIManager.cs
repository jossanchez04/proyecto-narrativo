using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCUIManager : MonoBehaviour
{
    public static NPCUIManager Instance;
    public Button addToExpeditionButton;

    public GameObject popupPanel;
    public TMP_Text nameText;
    public TMP_Text foodText;
    public TMP_Text waterText;
    public TMP_Text moraleText;
    public TMP_Text materialsText;
    public TMP_Text fuerzaText;
    public int counterExcursion;
    public Text cantidadExcursion;

    private NPC_Info currentNPC;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        counterExcursion = 0;
        popupPanel.SetActive(false);
        addToExpeditionButton.onClick.RemoveAllListeners();
        addToExpeditionButton.onClick.AddListener(OnAddToExpeditionClicked);
    }

    public void ShowNPCPopup(NPC_Info info)
    {
        if (popupPanel.activeSelf && currentNPC == info)
        {
            HidePopup();
            return;
        }

        currentNPC = info;

        nameText.text = info.npcName;
        foodText.text = $"{info.food}";
        waterText.text = $"{info.water}";
        moraleText.text = $"{info.morale}";
        materialsText.text = $"{info.materials}";
        fuerzaText.text = $"{info.strenght}";

        popupPanel.SetActive(true);
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
        currentNPC = null;
    }
    private void OnAddToExpeditionClicked()
    {
        if (currentNPC != null)
        {
            bool enviado = GameManager.Instance.AddToExpedition(currentNPC);
            if (enviado)
            {
                currentNPC.gameObject.SetActive(false);
                counterExcursion += 1;
                cantidadExcursion.text = counterExcursion.ToString();
                HidePopup();
            }
            else
            {
                Debug.Log("No se pudo enviar a la expedición. Límite alcanzado.");
            }
        }
    }
}
