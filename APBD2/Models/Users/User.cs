namespace APBD2.Models.Users;

//klasa bazowa dla użytkowników 

public abstract class User 
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }

    protected User(int id, string firstName, string lastName, string email, UserRole role)
    {
        Id = id; 
        FirstName = firstName; 
        LastName = lastName;
        Email = email; 
        Role = role;
    }

    //limit wypożyczen dla zadanego typu uzytkownika 
    public abstract int GetBorrowLimit(); 

    //limit okresu wypożyczenia dla zadanego typu uzytkowika 
    public abstract int GetMaxBorrowDays(); 

    public override string ToString()
    {
        return $"{FirstName} {LastName} {Role} - {Email}";
    }
}