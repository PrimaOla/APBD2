using APBD2.Models;
using System.Linq;

namespace APBD2.Services;

public class EquipmentService 
{
    private readonly List<Equipment> _equipment = new();

    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public List<Equipment> GetAll()
    {
        return _equipment;
    }

    public List<Equipment> GetAvailable()
    {
        return _equipment
        .Where(e => e.Status == EquipmentStatus.Available)
        .ToList();
    }

    public Equipment? GetById(int id)
    {
        return _equipment.FirstOrDefault(e => e.Id == id);
    }

    public void MarkAsUnavailable(int id){
        var equipment = GetById(id);

        if (equipment != null)
        {
            equipment.Status = EquipmentStatus.InMaintenance;
        }
    }
}