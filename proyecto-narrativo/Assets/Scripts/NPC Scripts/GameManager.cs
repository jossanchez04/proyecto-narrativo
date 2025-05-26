using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static event Action OnDayPassedEvent;

    public static int totalFood = 10;
    public static int totalWater = 10;
    public static int totalMorale = 10;

    public float dayLength = 5f;
    private float dayTimer = 0f;

    private List<NPC_Info> expeditionParty = new List<NPC_Info>();
    public int maxExpeditionSize = 4;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {

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
}

