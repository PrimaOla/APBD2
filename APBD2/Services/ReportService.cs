using APBD2.Models;
using APBD2.Models.Equipment;
using APBD2.Models.Users;
using System.Linq;

namespace APBD2.Services;

public class ReportService
{
   public void PrintSummary(List<Equipment> equipment, List<User> users, List<Rental> rentals)
    {
        Console.WriteLine("\n===== RENTAL SYSTEM REPORT =====");
        Console.WriteLine($"Total users: {users.Count}");
        Console.WriteLine($"Total equipment: {equipment.Count}");
        Console.WriteLine($"Available equipment: {equipment.Count(e => e.Status == EquipmentStatus.Available)}");
        Console.WriteLine($"Borrowed equipment: {equipment.Count(e => e.Status == EquipmentStatus.Borrowed)}");
        Console.WriteLine($"In maintenance: {equipment.Count(e => e.Status == EquipmentStatus.InMaintenance)}");
        Console.WriteLine($"Total rentals: {rentals.Count}");
        Console.WriteLine($"Active rentals: {rentals.Count(r => !r.IsReturned)}");
        Console.WriteLine($"Overdue rentals: {rentals.Count(r => r.IsOverdue)}");
        Console.WriteLine($"Total penalties: {rentals.Sum(r => r.Penalty)} zł");
        Console.WriteLine("================================\n");
    } 
}