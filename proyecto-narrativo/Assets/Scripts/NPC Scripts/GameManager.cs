using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public NPCPresentationManager npcPresentationManager;
    public GameObject npcPresentationPanel;

    public static GameManager Instance;

    public GameObject[] npcPrefabs;

    public int minStatValue = -5;
    public int maxStatValue = 5;

    public static event Action OnDayPassedEvent;

    public float shelterCapacity;

    private int numberOfSurvivors;

    public Text foodTextDisplay;
    public Text waterTextDisplay;
    public Text moraleTextDisplay;
    public Text materialsTextDisplay;
    public Text survivorsTextDisplay;

    public static int totalFood;
    public static int totalWater;
    public static int totalMorale;
    public static int totalMaterials;


    public static float totalFoodPercentage;
    public static float totalWaterPercentage;
    public static float totalMoralePercentage;
    

    public float dayLength = 25f;
    private float dayTimer = 0f;

    private List<NPC_Info> spawnedNPCs = new List<NPC_Info>();
    private List<NPC_Info> acceptedNPCs = new List<NPC_Info>();
    private List<NPC_Info> expeditionParty = new List<NPC_Info>();
    public int maxExpeditionSize = 4;

    public LayerMask obstacleLayerMask;
    public float npcRadius = 0.3f;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        npcPresentationManager.OnNPCAccepted += HandleNPCAccepted;
        npcPresentationManager.OnPresentationComplete += OnPresentationCompleteHandler;
        npcPresentationManager.OnPresentationComplete += SpawnAcceptedNPCs;
    }

    void Start()
    {
        totalFood = 10;
        totalWater = 10;
        totalMorale = 10;
        totalMaterials = 10;

        StartNewDay();
        //DayPassed();
    }

    private void OnDestroy()
    {
        npcPresentationManager.OnNPCAccepted -= HandleNPCAccepted;
        npcPresentationManager.OnPresentationComplete -= OnPresentationCompleteHandler;
        npcPresentationManager.OnPresentationComplete += SpawnAcceptedNPCs;
    }

    void Update()
    {
        if (!npcPresentationPanel.activeSelf)
        {
            dayTimer += Time.deltaTime;

            if (dayTimer >= dayLength)
            {
                dayTimer = 0f;
                StartNewDay();
                //DayPassed();
            }
        }

        if (totalFood <= 0 || totalWater <= 0 || totalMorale <= 0)
        {
            Debug.Log("Game Over! You have run out of resources.");
            
        }
    }

    private void DayPassed()
    {
        numberOfSurvivors = 0;
        foreach (var npc in acceptedNPCs)
        {
            numberOfSurvivors += 1;

            totalFood += npc.food;
            totalWater += npc.water;
            totalMorale += npc.morale;
            totalMaterials += npc.materials;
        }

        totalFoodPercentage = Mathf.RoundToInt(Mathf.Clamp01((float)totalFood / shelterCapacity)*100);
        totalWaterPercentage = Mathf.RoundToInt(Mathf.Clamp01((float)totalWater / shelterCapacity)*100);
        totalMoralePercentage = Mathf.RoundToInt(Mathf.Clamp01((float)totalMorale / shelterCapacity)*100);

        foodTextDisplay.text = totalFoodPercentage.ToString() + "%";
        waterTextDisplay.text = totalWaterPercentage.ToString() + "%";
        moraleTextDisplay.text = totalMoralePercentage.ToString() + "%";
        materialsTextDisplay.text = totalMaterials.ToString();
        survivorsTextDisplay.text = numberOfSurvivors.ToString();

        OnDayPassedEvent?.Invoke();
        Debug.Log("A new day has passed!");
        Debug.Log($"Food: {totalFood}, Water: {totalWater}, Morale: {totalMorale}");
    }

    public static void ConsumeResources(int food, int water, int morale)
    {
        totalFood += food;
        totalWater += water;
        totalMorale += morale;

        totalFood = Mathf.Max(0, totalFood);
        totalWater = Mathf.Max(0, totalWater);
        totalMorale = Mathf.Max(0, totalMorale);
    }

    // -------------------------
    //    EXPEDICIÓN
    // -------------------------

    public bool AddToExpedition(NPC_Info npc)
    {
        if (expeditionParty.Contains(npc))
        {
            Debug.Log("Este NPC ya está en la expedición.");
            return false;
        }

        if (expeditionParty.Count >= maxExpeditionSize)
        {
            Debug.Log("Ya hay suficientes NPCs en la expedición.");
            return false;
        }

        expeditionParty.Add(npc);
        acceptedNPCs.Remove(npc);
        npc.gameObject.SetActive(false);
        Debug.Log($"{npc.npcName} agregado a la expedición.");

        return true;
    }

    public void ClearExpedition()
    {
        expeditionParty.Clear();
    }

    public float SimulateExpeditionSuccess()
    {
        if (expeditionParty.Count == 0)
        {
            Debug.LogWarning("No hay NPCs en la expedición.");
            return 0f;
        }

        float totalStrength = 0f;
        float totalFoodEffect = 0f;
        float totalWaterEffect = 0f;

        foreach (var npc in expeditionParty)
        {
            totalStrength += npc.strenght;
            totalFoodEffect += npc.food;
            totalWaterEffect += npc.water;
        }

        float strengthScore = totalStrength * 10f;

        float resourceScore = (totalFoodEffect + totalWaterEffect) * 2f;

        float baseChance = strengthScore + resourceScore;
        float successChance = Mathf.Clamp(baseChance, 0f, 100f);

        Debug.Log($"Probabilidad de éxito de la expedición: {successChance}%");
        return successChance;
    }

    // -------------------------
    //    NPC Spawning
    // -------------------------

    public NPC_Info SpawnRandomNPC()
    {
        if (npcPrefabs == null || npcPrefabs.Length == 0)
        {
            Debug.LogWarning("No NPC prefabs assigned!");
            return null;
        }

        if (NPC_Stories.npcStories == null || NPC_Stories.npcStories.Count == 0)
        {
            Debug.LogWarning("No NPC stories found!");
            return null;
        }

        // Pick a random prefab
        GameObject prefab = npcPrefabs[UnityEngine.Random.Range(0, npcPrefabs.Length)];
        NPCStory story = NPC_Stories.npcStories[UnityEngine.Random.Range(0, NPC_Stories.npcStories.Count)];

        // Instantiate it (optionally set position and rotation)
        GameObject npcInstance = Instantiate(prefab, Vector3.zero, Quaternion.identity);

        // Deactivate the NPC instance to prevent it from being visible immediately
        npcInstance.SetActive(false);

        // Get the NPC_Wander component
        NPC_Wander wander = npcInstance.GetComponent<NPC_Wander>();

        Vector2 spawnPos = Vector2.zero;

        if (wander != null)
        {
            float halfWidth = wander.wanderWidth / 2f;
            float halfHeight = wander.wanderHeight / 2f;

            int maxAttempts = 20;
            bool positionFound = false;

            for (int i = 0; i < maxAttempts; i++)
            {
                float randomX = UnityEngine.Random.Range(wander.startingPosition.x - halfWidth, wander.startingPosition.x + halfWidth);
                float randomY = UnityEngine.Random.Range(wander.startingPosition.y - halfHeight, wander.startingPosition.y + halfHeight);

                Vector2 candidatePos = new Vector2(randomX, randomY);

                // Check if this position overlaps any obstacle collider
                Collider2D hit = Physics2D.OverlapCircle(candidatePos, npcRadius, obstacleLayerMask);
                if (hit == null)
                {
                    spawnPos = candidatePos;
                    positionFound = true;
                    break;
                }
            }

            if (!positionFound)
            {
                Debug.LogWarning("No free spawn position found after multiple attempts. Spawning at starting position.");
                spawnPos = wander.startingPosition;
            }

            npcInstance.transform.position = spawnPos;
        }
        else
        {
            Debug.LogWarning("NPC prefab missing NPC_Wander component, spawning at (0,0)");
        }

        // Get the NPC_Info component
        NPC_Info npcInfo = npcInstance.GetComponent<NPC_Info>();

        Debug.Log($"Instantiated NPC prefab: {prefab.name}");
        switch (prefab.name)
        {
            case "NPC1":
                npcInfo.avatarSprite = Resources.Load<Sprite>("Avatars/NPC1");
                break;
            case "NPC2":
                npcInfo.avatarSprite = Resources.Load<Sprite>("Avatars/NPC2");
                break;
            case "NPC3":
                npcInfo.avatarSprite = Resources.Load<Sprite>("Avatars/NPC3");
                break;
            case "NPC4":
                npcInfo.avatarSprite = Resources.Load<Sprite>("Avatars/NPC4");
                break;
            case "NPC5":
                npcInfo.avatarSprite = Resources.Load<Sprite>("Avatars/NPC5");
                break;
        }

        if (npcInfo != null)
        {
            // Assign random stats
            npcInfo.food = story.food;
            npcInfo.water = story.water;
            npcInfo.morale = story.morale;
            npcInfo.materials = story.materials;
            npcInfo.strenght = story.strenght;

            // Assign a random backstory
            npcInfo.npcBackstory = story.npcBackstory;

            // Optionally assign a random or unique npcName (e.g. "NPC" + a number)
            npcInfo.npcName = story.npcName;
        }
        else
        {
            Debug.LogWarning("The instantiated NPC prefab does not have an NPC_Info component.");
        }
        Debug.Log($"NPC {npcInfo.npcName} spawned with backstory: {npcInfo.npcBackstory} and stats: Food={npcInfo.food}, Water={npcInfo.water}, Morale={npcInfo.morale}, Materials={npcInfo.materials}, Strength={npcInfo.strenght}.");
        return npcInfo;
    }

    // -------------------------
    //    Day Management
    // -------------------------
    public void StartNewDay()
    {
        spawnedNPCs.Clear();

        for (int i = 0; i < 6; i++)
        {
            spawnedNPCs.Add(SpawnRandomNPC());
        }

        npcPresentationPanel.SetActive(true);

        npcPresentationManager.PresentNPCs(spawnedNPCs);
    }






    private void HandleNPCAccepted(NPC_Info npc)
    {
        acceptedNPCs.Add(npc);
    }

    public void SpawnAcceptedNPCs()
    {
        foreach (var npc in acceptedNPCs)
        {
            // Here you can implement logic to spawn the accepted NPCs in the game world
            // For example, instantiate them at a specific location or add them to a list
            Debug.Log($"Accepted NPC: {npc.npcName} with backstory: {npc.npcBackstory}.");
            SpawnNPCInWorld(npc);
        }
    }

    private void SpawnNPCInWorld(NPC_Info npc)
    {
        GameObject npcGameObject = npc.gameObject;
        npcGameObject.SetActive(true);

        var wander = npcGameObject.GetComponent<NPC_Wander>();
        if (wander != null)
        {
            float halfWidth = wander.wanderWidth / 2f;
            float halfHeight = wander.wanderHeight / 2f;

            float randomX = UnityEngine.Random.Range(wander.startingPosition.x - halfWidth, wander.startingPosition.x + halfWidth);
            float randomY = UnityEngine.Random.Range(wander.startingPosition.y - halfHeight, wander.startingPosition.y + halfHeight);

            npcGameObject.transform.position = new Vector2(randomX, randomY);
        }
        else
        {
            npcGameObject.transform.position = Vector3.zero;
        }
    }

    private void OnPresentationCompleteHandler()
    {
        Debug.Log("NPC presentation complete, hiding panel.");
        npcPresentationPanel.SetActive(false); // Hide the NPC presentation panel during gameplay
        DayPassed();
    }
}

