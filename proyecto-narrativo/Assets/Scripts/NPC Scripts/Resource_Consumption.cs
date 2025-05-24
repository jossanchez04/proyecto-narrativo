using UnityEngine;

public class Resource_Consumption : MonoBehaviour
{
    [Header("NPC Personal Stats")]
    public int food = 1;
    public int water = 1;
    public int morale = 1;

    [Header("NPC Morale Impact")]
    public int moraleThreshold = 3;

    void OnEnable()
    {
        GameManager.OnDayPassedEvent += OnDayPassed;
    }

    void OnDisable()
    {
        GameManager.OnDayPassedEvent -= OnDayPassed;
    }

    private void OnDayPassed()
    {
        GameManager.ConsumeResources(food, water, morale);
    }
}
