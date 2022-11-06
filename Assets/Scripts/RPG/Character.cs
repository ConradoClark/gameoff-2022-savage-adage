using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.RPG;
using Licht.Impl.Orchestration;
using Licht.Unity.Objects;
using UnityEditorInternal;
using UnityEngine;

public class Character : BaseGameObject
{
    public int MaxHP;
    public int CurrentHP { get; protected set; }

    public int AttackBonus;
    public int DefenseBonus;
    public float SpeedMultiplier = 1;

    public CharacterAI AI;
    public CharacterAction CurrentAction { get; protected set; }

    public event Action<CharacterAction> OnCurrentActionChanged;
    public event Action<CharacterAction> OnActionPerformed;
    public event Action<CharacterAction> OnActionFinished;

    protected override void OnAwake()
    {
        CurrentHP = MaxHP;
    }

    private void OnEnable()
    {
        DefaultMachinery.AddBasicMachine(HandleAI());
    }

    private IEnumerable<IEnumerable<Action>> HandleAI()
    {
        while (enabled && AI != null)
        {
            CurrentAction = AI.GetNextAction();
            OnCurrentActionChanged?.Invoke(CurrentAction);

            yield return TimeYields.WaitSeconds(GameTimer, CurrentAction.ActionChargeInSeconds / SpeedMultiplier);

            OnActionPerformed?.Invoke(CurrentAction);

            yield return TimeYields.WaitSeconds(GameTimer, CurrentAction.ActionDurationInSeconds / SpeedMultiplier);

            OnActionFinished?.Invoke(CurrentAction);

            yield return TimeYields.WaitOneFrameX;
        }
    }
}
