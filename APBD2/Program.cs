using APBD2.Exceptions;
using APBD2.Models;
using APBD2.Models.EquipmentTypes;
using APBD2.Models.Users;
using APBD2.Services;
using APBD2.UI;

namespace APBD2;

public class Program
{
    public static void Main(string[] args)
    {
        var idGenerator = new IdGeneratorService();
        var policyService = new RentalPolicyService();
        var equipmentService = new EquipmentService();
        var userService = new UserService();
        var rentalService = new RentalService(policyService);
        var reportService = new ReportService();
        var ui = new ConsoleUI();

        // =========================
        // 1. DODANIE SPRZĘTU
        // =========================
        var laptop1 = new Laptop(
            idGenerator.NextEquipmentId(),
            "Dell Latitude",
            new DateTime(2023, 1, 10),
            3200m,
            16,
            "Intel i5"
        );

        var laptop2 = new Laptop(
            idGenerator.NextEquipmentId(),
            "Lenovo ThinkPad",
            new DateTime(2022, 11, 5),
            4100m,
            32,
            "Intel i7"
        );

        var camera1 = new Camera(
            idGenerator.NextEquipmentId(),
            "Canon EOS",
            new DateTime(2021, 6, 12),
            2800m,
            24,
            true
        );

        var projector1 = new Projector(
            idGenerator.NextEquipmentId(),
            "Epson X200",
            new DateTime(2020, 9, 3),
            2300m,
            3500,
            "1920x1080"
        );

        equipmentService.AddEquipment(laptop1);
        equipmentService.AddEquipment(laptop2);
        equipmentService.AddEquipment(camera1);
        equipmentService.AddEquipment(projector1);

        // =========================
        // 2. DODANIE UŻYTKOWNIKÓW
        // =========================
        var student1 = new Student(
            idGenerator.NextUserId(),
            "Anna",
            "Nowak",
            "anna.nowak@edu.pl",
            "s12345"
        );

        var student2 = new Student(
            idGenerator.NextUserId(),
            "Jan",
            "Kowalski",
            "jan.kowalski@edu.pl",
            "s54321"
        );

        var employee1 = new Employee(
            idGenerator.NextUserId(),
            "Piotr",
            "Wiśniewski",
            "piotr.wisniewski@company.pl",
            "IT"
        );

        userService.AddUser(student1);
        userService.AddUser(student2);
        userService.AddUser(employee1);

        // =========================
        // WYŚWIETLENIE STANU POCZĄTKOWEGO
        // =========================
        ui.PrintEquipment(equipmentService.GetAll());
        ui.PrintUsers(userService.GetAllUsers());

        // =========================
        // 3. POPRAWNE WYPOŻYCZENIE
        // =========================
        try
        {
            rentalService.BorrowEquipment(idGenerator.NextRentalId(), student1, laptop1, 7);
            rentalService.BorrowEquipment(idGenerator.NextRentalId(), student1, camera1, 5);

            Console.WriteLine("\nCorrect borrow operations completed.");
        }
        catch (EquipmentNotAvailableException ex)
        {
            Console.WriteLine($"Equipment error: {ex.Message}");
        }
        catch (BusinessRuleException ex)
        {
            Console.WriteLine($"Business rule error: {ex.Message}");
        }

        // =========================
        // 4. NIEPOPRAWNA OPERACJA
        // student ma limit 5, ale tu pokażemy przekroczenie dni
        // =========================
        try
        {
            rentalService.BorrowEquipment(idGenerator.NextRentalId(), student1, projector1, 20);
        }
        catch (EquipmentNotAvailableException ex)
        {
            Console.WriteLine($"Equipment error: {ex.Message}");
        }
        catch (BusinessRuleException ex)
        {
            Console.WriteLine($"\nExpected business rule error: {ex.Message}");
        }

        // =========================
        // 5. ZWROT W TERMINIE
        // =========================
        try
        {
            var rentalToReturn = rentalService.GetActiveRentalsForUser(student1.Id).First();
            rentalService.ReturnEquipment(rentalToReturn.Id);

            Console.WriteLine("\nOne equipment returned on time.");
        }
        catch (BusinessRuleException ex)
        {
            Console.WriteLine($"Return error: {ex.Message}");
        }

        // =========================
        // 6. ZWROT OPÓŹNIONY Z KARĄ
        // =========================
        try
        {
            rentalService.BorrowEquipment(idGenerator.NextRentalId(), employee1, projector1, 5);

            var employeeRental = rentalService
                .GetActiveRentalsForUser(employee1.Id)
                .First(r => r.Equipment.Id == projector1.Id);

            // sztucznie ustawiamy przeterminowanie
            employeeRental.DueDate = DateTime.Now.AddDays(-3);

            rentalService.ReturnEquipment(employeeRental.Id);

            Console.WriteLine("\nLate return completed with penalty.");
        }
        catch (EquipmentNotAvailableException ex)
        {
            Console.WriteLine($"Equipment error: {ex.Message}");
        }
        catch (BusinessRuleException ex)
        {
            Console.WriteLine($"Business rule error: {ex.Message}");
        }

        // =========================
        // 7. OZNACZENIE SPRZĘTU JAKO NIEDOSTĘPNEGO
        // =========================
        equipmentService.MarkAsUnavailable(laptop2.Id);

        // =========================
        // 8. AKTYWNE WYPOŻYCZENIA UŻYTKOWNIKA
        // =========================
        ui.PrintRentals(
            rentalService.GetActiveRentalsForUser(student1.Id),
            "ACTIVE RENTALS FOR STUDENT 1"
        );

        // =========================
        // 9. PRZETERMINOWANE WYPOŻYCZENIA
        // =========================
        ui.PrintRentals(
            rentalService.GetOverdueRentals(),
            "OVERDUE RENTALS"
        );

        // =========================
        // 10. LISTA SPRZĘTU
        // =========================
        ui.PrintEquipment(equipmentService.GetAll());

        Console.WriteLine("\n--- AVAILABLE EQUIPMENT ---");
        foreach (var eq in equipmentService.GetAvailable())
        {
            Console.WriteLine(eq);
        }

        // =========================
        // 11. RAPORT KOŃCOWY
        // =========================
        reportService.PrintSummary(
            equipmentService.GetAll(),
            userService.GetAllUsers(),
            rentalService.GetAllRentals()
        );
    }
}