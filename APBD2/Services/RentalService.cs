using APBD2.Exceptions;
using APBD2.Models;
using System.Linq;

namespace APBD2.Services;

public class RentalService
{
    private readonly List<Rental> _rentals = new(); 
    private readonly RentalPolicyService _policyService; 

    public RentalService(RentalPolicyService policyService)
    {
        _policyService = policyService; 
    }

    public void BorrowEquipment(int rentalId, User user, Equipment equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new EquipmentNotAvailableException(
                $"Equipment '{equipment.Name}' (ID: {equipment.Id}) is not available. Current status: {equipment.Status}."
            );
        }

        int activeRentalCount = _rentals.Count(r => r.User.Id == user.Id && !r.IsReturned);
        int userLimit = _policyService.GetUserLimit(user);

        if (activeRentalCount >= userLimit)
        {
            throw new BusinessRuleException(
                $"User has reached the borrowing limit ({userLimit})."
            );
        }

        DateTime borrowDate = DateTime.Now;
        DateTime dueDate = borrowDate.AddDays(days);

        var rental = new Rental(rentalId, equipment, user, borrowDate, dueDate);

        _rentals.Add(rental);
        equipment.Status = EquipmentStatus.Borrowed;
    }

    public void ReturnEquipment(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId && !r.IsReturned);
        
        if (rental == null)
        {
            throw new BusinessRuleException("Active rental not found");
        }

        DateTime returnDate = DateTime.Now; 
        rental.ReturnDate = ReturnDate;
        rental.Penalty = _policyService.CalculatePenalty(rental.DueDate, returnDate);
        rental.Equipment.Status = EquipmentStatus.Available;
    }

    public List<Rental> GetAllRentals()
    {
        return _rentals;
    }

    public List<Rental> GetActiveRentalsForUser(int userId)
    {
        return _rentals.Where(r => r.User.Id ==userId && !r.IsReturned).ToList();

    }

    public List<Rental>GetOverdueRentals()
    {
        return _rentals.Where(r => r.IsOverdue).ToList();
    }
}

