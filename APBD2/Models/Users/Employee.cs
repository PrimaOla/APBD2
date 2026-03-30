namespace APBD2.Models.Users;

public class Employee : User
{
    public string Department { get; set; }

    public Employee(int id, string firstName, string lastName, string email, string department)
    : base(id, firstName, lastName, email, UserRole.Employee)
    {
        Department = department;
    }

    public override int GetBorrowLimit()
    {
        return 10; //pracownik moze wypozyczyc 10 na raz
    }

    public override int GetMaxBorrowDays()
    {
        return 30; //pracownik moze trzymac sprzet do 30 dni
    }
}