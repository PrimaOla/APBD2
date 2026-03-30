using APBD2.Models;

namespace APBD2.Services;

public class RentalPolicyService
{
    private const decimal PenaltyPerDay = 15m; 

    public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate <= dueDate)
        {
            return 0;
        }

        
        int overduDays = (returnDate.Date - dueDate.Date).Days;
        return overduDays * PenaltyPerDay;
    }

}