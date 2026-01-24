using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor 1: Default to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: For whole numbers (e.g., 5 becomes 5/1)
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor 3: For specific fractions (e.g., 3/4)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter and Setter for the Top (Numerator)
    public int GetTop() { return _top; }
    public void SetTop(int top) { _top = top; }

    // Getter and Setter for the Bottom (Denominator)
    public int GetBottom() { return _bottom; }
    public void SetBottom(int bottom) { _bottom = bottom; }

    // Returns the fraction in "3/4" format
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns the decimal value (e.g., 0.75)
    public double GetDecimalValue()
    {
        // We cast to (double) so it doesn't do integer division
        return (double)_top / (double)_bottom;
    }
}
