using Licht.Unity.Objects;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextNumberCounter : BaseUIObject
{
    public UINumberFormatter NumberFormatter;
    public NumberCounter Counter;
    private TMP_Text _text;

    protected override void OnAwake()
    {
        base.OnAwake();
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        Counter.OnValueChanged += Counter_OnValueChanged;
        UpdateText(Counter.CurrentValue);
    }

    private void OnDisable()
    {
        Counter.OnValueChanged -= Counter_OnValueChanged;
    }

    private void Counter_OnValueChanged(NumberCounter.NumberCounterChangeEventArgs obj)
    {
        UpdateText(obj.NewValue);
    }

    private void UpdateText(int value)
    {
        _text.text = NumberFormatter == null ? value.ToString() : NumberFormatter.Format(value);
    }
}
