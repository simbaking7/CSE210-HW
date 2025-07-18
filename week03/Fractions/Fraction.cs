public class Fraction
{
    private int top;    // Numerator
    private int bottom; // Denominator

    public Fraction()
    {
        this.top = 1;
        this.bottom = 1;
    }
    public Fraction(int top)
    {
        this.top = top;
        this.bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        this.top = top;
        if (bottom != 0)
        {
            this.bottom = bottom;
        }
        else
        {
            this.bottom = 1; 
        }
    }
    // Getters
    public int GetTop()
    {
        return top;
    }

    public int GetBottom()
    {
        return bottom;
    }

    // Setters
    public void SetTop(int top)
    {
        this.top = top;
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            this.bottom = bottom;
        }
    }
    public string GetFractionString()
    {
        return top + "/" + bottom;
    }

    public double GetDecimalValue()
    {
        return (double)top / bottom;
    }
}