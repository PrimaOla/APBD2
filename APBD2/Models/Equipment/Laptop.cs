namespace APBD2.Models.Equipment;

//klasa Laptop 

public class Laptop : Equipment 
{
    public int RamGb {get; set; }
    public string Processor {get; set; }
    
    public Laptop(int id, string name, DateTime purchaseDate, decimal value, int ramGb, string processor)
    : base(id, name, purchaseDate, value)
    {
        RamGb = ramGb; 
        Processor = processor;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", RAM: {RamGb} GB, CPU: {Processor}";
    }
}