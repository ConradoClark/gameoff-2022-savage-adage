using UnityEngine;

[CreateAssetMenu(fileName = "RPG", menuName = "RPG/CharacterAction", order = 1)]
public class CharacterAction : ScriptableObject
{
    /*
     * Action: Charge Time + (Execute Action) + Duration Time -> Next Action
     */
    public float ActionChargeInSeconds;
    public float ActionDurationInSeconds;
    public string ActionName;
    public Color ActionColor; // unused for now

    public int Strength;
    public CharacterActionType ActionType;
}
