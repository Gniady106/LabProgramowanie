namespace SimpleCalculator.Models;

public class Birth
{
    public string Name { get; set; }
    
    public DateTime? DateOfB { get; set; }



    public bool IsValid()
    {
        if (Name == null || DateOfB == null || DateOfB < DateTime.Now)
        {
            return true;
        }

        return false;
    }


    public int AgeCalc()
    {
        if (DateOfB == null)
        {
            return 0;
        }

        var today = DateTime.Now;
        var age = today.Year - DateOfB.Value.Year;
        if (today < today.AddYears(age) )
        {
            --age;
        }

        return age;
        
    }
    
    
    
    
    
}