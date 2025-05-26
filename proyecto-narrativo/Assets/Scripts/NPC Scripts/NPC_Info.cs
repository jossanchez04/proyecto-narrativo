using UnityEngine;

public class NPC_Info : MonoBehaviour
{
    public string npcName;
    public string npcBackstory;

    [Header("NPC Personal Stats")]
    public int food;
    public int water;
    public int morale;
    public int materials;
    public int strenght;

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
