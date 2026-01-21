public class Fraction
{
    private int _top;
    private int _bottom;

    // 1) Constructor sin parámetros -> 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2) Constructor con 1 parámetro (top) -> top/1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 3) Constructor con 2 parámetros (top, bottom) -> top/bottom
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
        return (double)_top / _bottom;
    }
}