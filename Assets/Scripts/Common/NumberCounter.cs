using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Common", menuName = "Common/NumberCounter", order = 1)]
public class NumberCounter : ScriptableObject
{
    public class NumberCounterChangeEventArgs
    {
        public int OldValue;
        public int NewValue;
    }

    public int InitialValue;

    private int _currentValue;

    public event Action<NumberCounterChangeEventArgs> OnValueChanged;
    public event Action<NumberCounter> OnReset;

    public int CurrentValue
    {
        get => _currentValue;
        set
        {
            var old = _currentValue;
            _currentValue = value;

            OnValueChanged?.Invoke(new NumberCounterChangeEventArgs
            {
                OldValue = old,
                NewValue = value
            });
        }
    }

    public void ResetCounter()
    {
        CurrentValue = InitialValue;
        OnReset?.Invoke(this);
    }

    public void ResetCounter(NumberCounter @base)
    {
        InitialValue = @base.InitialValue;
        ResetCounter();
    }

}
