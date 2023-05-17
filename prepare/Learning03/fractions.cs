using System;

class Fraction
{
    private int _top;
    private int _bottom;
    // Each one of these public fraction has a new value then the other
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
   public Fraction(int top, int bottom)
   {
    _top = top;
    _bottom = bottom;
   }

    public string GetFractionString()
    {
        string message = $"{_top}/{_bottom}";
        return message;
    }
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}