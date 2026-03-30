namespace APBD2.Services;

public class IdGeneratorService
{
    private int _equipmentId = 1;
    private int _userId = 1; 
    private int _rentalId = 1; 
    
    public int NextEquipmentId(){
        return _equipmentId++;
    }
    
    public int NextUserId()
    {
        return _userId++;
    }

    public int NextRentalId()
    {
        return _rentalId++;
    }
}