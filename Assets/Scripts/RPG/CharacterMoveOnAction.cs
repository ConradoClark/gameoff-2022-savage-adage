using Licht.Impl.Orchestration;
using Licht.Unity.Extensions;
using Licht.Unity.Objects;
using UnityEngine;

public class CharacterMoveOnAction : BaseGameObject
{
    public Character Character;
    public Vector2 Direction;
    private void OnEnable()
    {
        Character.OnActionPerformed += Character_OnActionPerformed;
        Character.OnActionFinished += Character_OnActionFinished; 
    }

    private void OnDisable()
    {
        Character.OnActionPerformed -= Character_OnActionPerformed;
        Character.OnActionFinished -= Character_OnActionFinished;
    }

    private void Character_OnActionPerformed(CharacterAction obj)
    {
        var move = Character.transform.GetAccessor().LocalPosition
            .X
            .Increase(Direction.x * 1f)
            .Over(0.2f / Character.SpeedMultiplier)
            .UsingTimer(GameTimer)
            .Easing(EasingYields.EasingFunction.QuadraticEaseOut)
            .Build();

        DefaultMachinery.AddBasicMachine(move);
    }

    private void Character_OnActionFinished(CharacterAction obj)
    {
        var move = Character.transform.GetAccessor().LocalPosition
            .X
            .Increase(-Direction.x * 1f)
            .Over(0.2f / Character.SpeedMultiplier)
            .UsingTimer(GameTimer)
            .Easing(EasingYields.EasingFunction.QuadraticEaseInOut)
            .Build();

        DefaultMachinery.AddBasicMachine(move);
    }

}
