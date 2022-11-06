public class HPNumberFormatter : UINumberFormatter
{
    public NumberCounter HPCounter;
    public override string Format(int value)
    {
        return $"{value} / {HPCounter.InitialValue}";
    }
}

