namespace APBD2.Models;

//klasa do reprezentowania pojedynczego wypozyczenia sprzetu 

public class Rental 
{
    public int Id {get; set; }
    public Equipment Equipment {get; set; }
    public User User {get; set; }
    public DateTime BorrowDate {get; set; }
    public DateTime DueDate {get; set; }
    public DateTime? ReturnDate {get; set; }
    public decimal Penalty {get; set; }

    public bool IsReturned => ReturnDate.HasValue;
    public bool IsOverdue => !IsReturned && DateTime.Now > DueDate; 

    public Rental(int id, Equipment equipment, User user, DateTime borrowDate, DateTime dueDate)
    {
        Id = id; 
        Equipment = equipment; 
        User = user;
        BorrowDate = borrowDate; 
        DueDate = dueDate; 
        ReturnDate = null; 
        Penalty = 0;
    }

    public override string ToString()
    {
        string returnInfo = IsReturned ? ReturnDate!.Value.ToShortDateString() : "Not returned";
        return $"Rental ID: {Id}, User: {User.FirstName} {User.LastName}, Equipment: {Equipment.Name}, Borrowed: {BorrowDate.ToShortDateString()}, Due: {DueDate.ToShortDateString()}, Returned: {returnInfo}, Penalty: {Penalty} zł";
    }


}
