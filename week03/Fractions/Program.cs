using System;

class Program
{
    static void Main(string[] args)
    {
        
        Fraction f1 = new Fraction();          
        Fraction f2 = new Fraction(5);         
        Fraction f3 = new Fraction(3, 4);      
        Fraction f4 = new Fraction(1, 3);      

        
        Console.WriteLine(f1.GetFractionString());   
        Console.WriteLine(f1.GetDecimalValue());    

        Console.WriteLine(f2.GetFractionString());   
        Console.WriteLine(f2.GetDecimalValue());     

        Console.WriteLine(f3.GetFractionString());   
        Console.WriteLine(f3.GetDecimalValue());    

        Console.WriteLine(f4.GetFractionString());   
        Console.WriteLine(f4.GetDecimalValue());     

        
        Fraction f5 = new Fraction(2, 5);
        Console.WriteLine("\nOriginal f5: " + f5.GetFractionString());

        
        f5.SetTop(7);
        f5.SetBottom(8);

        
        Console.WriteLine("Updated f5: " + f5.GetFractionString());     
        Console.WriteLine("Updated f5 Decimal: " + f5.GetDecimalValue()); 
    }
}
