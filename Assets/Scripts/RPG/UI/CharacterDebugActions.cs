using UnityEngine;

public class CharacterDebugActions : MonoBehaviour
{
    public Character Character;

    private void OnEnable()
    {
        Character.OnCurrentActionChanged += Character_OnCurrentActionChanged;
        Character.OnActionPerformed += Character_OnActionPerformed;
        Character.OnActionFinished += Character_OnActionFinished;
    }

    private void Character_OnActionFinished(CharacterAction obj)
    {
        Debug.Log($"Character {Character.name} - action finished: '{obj.ActionName}'");
    }

    private void Character_OnActionPerformed(CharacterAction obj)
    {
        Debug.Log($"Character {Character.name} - action performed: '{obj.ActionName}'");
    }

    private void Character_OnCurrentActionChanged(CharacterAction obj)
    {
        Debug.Log($"Character {Character.name} - action changed to: '{obj.ActionName}'");
    }

    private void OnDisable()
    {
        Character.OnCurrentActionChanged -= Character_OnCurrentActionChanged;
        Character.OnActionPerformed -= Character_OnActionPerformed;
        Character.OnActionFinished -= Character_OnActionFinished;
    }
}
