using System;
using System.Collections.Generic;
using Assets.Scripts.RPG;
using Licht.Impl.Orchestration;
using Licht.Unity.Objects;

public class Character : BaseGameObject
{
    public NumberCounter HP;

    public int AttackBonus;
    public int DefenseBonus;
    public float SpeedMultiplier = 1;

    public CharacterAI AI;
    public CharacterAction CurrentAction { get; protected set; }

    public event Action<CharacterAction> OnCurrentActionChanged;
    public event Action<CharacterAction> OnActionPerformed;
    public event Action<CharacterAction> OnActionFinished;

    public bool IsDead => HP.CurrentValue <= 0;

    private Character _opposingCharacter;

    protected override void OnAwake()
    {
        HP.ResetCounter();

        _opposingCharacter = SceneObject<PlayerCharacterTag>.Instance().Character == this ? 
            SceneObject<EnemyCharacterTag>.Instance().Character :
            SceneObject<PlayerCharacterTag>.Instance().Character;
    }

    private void OnEnable()
    {
        DefaultMachinery.AddBasicMachine(HandleAI());
    }

    private IEnumerable<IEnumerable<Action>> HandleAI()
    {
        while (enabled && AI != null)
        {
            while (_opposingCharacter.IsDead)
            {
                yield return TimeYields.WaitOneFrameX;
            }

            CurrentAction = AI.GetNextAction();

            OnCurrentActionChanged?.Invoke(CurrentAction);

            yield return TimeYields.WaitSeconds(GameTimer, CurrentAction.ActionChargeInSeconds / SpeedMultiplier);

            OnActionPerformed?.Invoke(CurrentAction);

            yield return TimeYields.WaitSeconds(GameTimer, CurrentAction.ActionDurationInSeconds / SpeedMultiplier);
            CalculateAction();

            OnActionFinished?.Invoke(CurrentAction);

            yield return TimeYields.WaitOneFrameX;
        }
    }

    private void CalculateAction()
    {
        switch (CurrentAction.ActionType)
        {
            case CharacterActionType.Damage:
                CalculateDamage(this, _opposingCharacter);
                break;
            default:
                break;
        }

    }

    private void CalculateDamage(Character source, Character target)
    {
        var damage = CurrentAction.Strength + source.AttackBonus;
        target.HP.CurrentValue = Math.Clamp(target.HP.CurrentValue - damage, 0, target.HP.InitialValue);
    }
}
