namespace APBD2.Models.Users;

public class Student : User
{
    public string IndexNumber {get; set; }

    public Student(int id, string firstName, string lastName, string email, string indexNumber)
    : base(id, firstName, lastName, email UserRole.Student) 
    {
        IndexNumber = indexNumber;
    }

    public override int GetBorrowLimit()
    {
        return 3; // Student może mieć max 3 wypożyczenia
    }

    public override int GetMaxBorrowDays()
    {
        return 14; //student moze trzymac sprzet max 2 tygodnie 
    }
}