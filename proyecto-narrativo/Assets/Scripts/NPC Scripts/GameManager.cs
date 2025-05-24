using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action OnDayPassedEvent;

    public static int totalFood = 10;
    public static int totalWater = 10;
    public static int totalMorale = 10;

    public float dayLength = 5f;
    private float dayTimer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
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
            // Here you can add logic to end the game or restart it
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
}
