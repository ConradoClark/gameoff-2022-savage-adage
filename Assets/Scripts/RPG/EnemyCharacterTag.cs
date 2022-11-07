using Licht.Unity.Objects;
using UnityEngine;

[RequireComponent(typeof(Character))]
[DefaultExecutionOrder(-1)]
public class EnemyCharacterTag : SceneObject<EnemyCharacterTag>
{
    public Character Character { get; private set; }

    private void Awake()
    {
        Character = GetComponent<Character>();
    }
}
