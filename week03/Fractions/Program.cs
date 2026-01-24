using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor for 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor for number/1 (e.g., 5/1)
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor for top/bottom (e.g., 3/4)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}