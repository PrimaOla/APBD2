namespace APBD2.Models; 

//Klasa bazowa dla wszystkich typów sprzętu 
//Reprezentuje wspólne cechy: ID, nazwę, datę nabycia, stan, wartość

public abstract class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime PurchaseDate { get; set; }
    public EquipmentStatus Status{ get; set; }
    public decimal Value { get; set; }

    protected Equipment(int id, string name, DateTime purchaseDate, decimal value)
    {
        Id = id; 
        Name = name;
        PurchaseDate = purchaseDate; 
        Status = EquipmentStatus.Available;
        Value=value;
    }

    public override string ToString()
    {
        return $"[{GetType().Name} ID: {Id}, Name: {Name}, Status: {Status}, Value: {value} zł]";
    }
}