using APBD2.Models;

namespace APBD2.Services;

public class RentalPolicyService
{
    private const int StudentLimit = 2; 
    private const int EmployeeLimit = 5; 
    private const decimal PenaltyPerDay = 15m; 

    public int GetUserLimit(User user)
    {
        return user.UserType switch
        {
            UserType.Student => StudentLimit,
            UserType.Employee => EmployeeLimit,
            _ => 0
        };
    }

    public decimal CalculatePenalty(DateTime dueDate, DataTime returnDate)
    {
        if (returnDate <= dueDate)
        {
            return 0;
        }

        
        int overduDays = (returnDate.Date - dueDate.Date).Days;
        return overduDays * PenaltyPerDay;
    }

}