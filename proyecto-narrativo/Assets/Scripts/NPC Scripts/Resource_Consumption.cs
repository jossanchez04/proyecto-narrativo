using UnityEngine;

public class Resource_Consumption : MonoBehaviour
{
    [Header("NPC Personal Stats")]
    public int food;
    public int water;
    public int morale;

    [Header("NPC Morale Impact")]
    public int moraleThreshold;

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
