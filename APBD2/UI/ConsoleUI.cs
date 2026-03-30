using APBD2.Models;
using APBD2.Models.EquipmentTypes;
using APBD2.Models.Users;

namespace APBD2.UI;

public class ConsoleUI 
{
    public void PrintEquipment(List<Equipment> equipment)
    {
        Console.WriteLine("\n--- EQUIPMENT ---");
        foreach (var item in equipment)
        {
            Console.WriteLine(item);
        }
    }

    public void PrintUsers(List<User> users)
    {
        Console.WriteLine("\n--- USERS ---");
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }

    public void PrintRentals(List<Rental> rentals, string title)
    {
        Console.WriteLine($"\n--- {title} ---");
        foreach (var rental in rentals)
        {
            Console.WriteLine(rental);
        }
    }
}