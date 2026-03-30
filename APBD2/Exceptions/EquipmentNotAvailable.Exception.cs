namespace APBD2.Exceptions; 

public class EquipmentNotAvailableException : BusinessRuleException
{
    public EquipmentNotAvailableException()
    : base("This equipment is not available for borrowing")
    {

    }
    public EquipmentNotAvailableException(string message)
    : base(message)
    {

    }
}