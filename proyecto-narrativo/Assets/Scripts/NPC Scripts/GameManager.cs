using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public NPCPresentationManager npcPresentationManager;

    public static GameManager Instance;

    public GameObject[] npcPrefabs;

    public int minStatValue = -5;
    public int maxStatValue = 5;

    public static event Action OnDayPassedEvent;

    public static int totalFood = 10;
    public static int totalWater = 10;
    public static int totalMorale = 10;

    public float dayLength = 5f;
    private float dayTimer = 0f;

    private List<NPC_Info> spawnedNPCs = new List<NPC_Info>();
    private List<NPC_Info> acceptedNPCs = new List<NPC_Info>();
    private List<NPC_Info> expeditionParty = new List<NPC_Info>();
    public int maxExpeditionSize = 4;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        SpawnRandomNPC();
    }

    void Update()
    {
        dayTimer += Time.deltaTime;

        if (dayTimer >= dayLength)
        {
            dayTimer = 0f;
            DayPassed();
        }

        if (totalFood <= 0 || totalWater <= 0 || totalMorale <= 0)
        {
            Debug.Log("Game Over! You have run out of resources.");
            
        }
    }

    private void DayPassed()
    {
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

    public void SpawnRandomNPC()
    {
        if (npcPrefabs == null || npcPrefabs.Length == 0)
        {
            Debug.LogWarning("No NPC prefabs assigned!");
            return;
        }

        if (NPC_Stories.npcStories == null || NPC_Stories.npcStories.Count == 0)
        {
            Debug.LogWarning("No NPC stories found!");
            return;
        }

        // Pick a random prefab
        GameObject prefab = npcPrefabs[UnityEngine.Random.Range(0, npcPrefabs.Length)];
        NPCStory story = NPC_Stories.npcStories[UnityEngine.Random.Range(0, NPC_Stories.npcStories.Count)];

        // Instantiate it (optionally set position and rotation)
        GameObject npcInstance = Instantiate(prefab, Vector3.zero, Quaternion.identity);

        // Get the NPC_Wander component
        NPC_Wander wander = npcInstance.GetComponent<NPC_Wander>();

        if (wander != null)
        {
            // Random position inside wander area rectangle
            float halfWidth = wander.wanderWidth / 2f;
            float halfHeight = wander.wanderHeight / 2f;

            float randomX = UnityEngine.Random.Range(wander.startingPosition.x - halfWidth, wander.startingPosition.x + halfWidth);
            float randomY = UnityEngine.Random.Range(wander.startingPosition.y - halfHeight, wander.startingPosition.y + halfHeight);

            npcInstance.transform.position = new Vector2(randomX, randomY);
        }
        else
        {
            Debug.LogWarning("NPC prefab missing NPC_Wander component, spawning at (0,0)");
        }

        // Get the NPC_Info component
        NPC_Info npcInfo = npcInstance.GetComponent<NPC_Info>();

        if (npcInfo != null)
        {
            // Assign random stats
            npcInfo.food = UnityEngine.Random.Range(minStatValue, maxStatValue + 1);
            npcInfo.water = UnityEngine.Random.Range(minStatValue, maxStatValue + 1);
            npcInfo.morale = UnityEngine.Random.Range(minStatValue, maxStatValue + 1);
            npcInfo.materials = UnityEngine.Random.Range(minStatValue, maxStatValue + 1);
            npcInfo.strenght = UnityEngine.Random.Range(minStatValue, maxStatValue + 1);

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
    }
}

