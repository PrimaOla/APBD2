namespace APBD2.Models.Equipment;

//stany wypożyczenia sprzętu 

public enum EquipmentStatus
{
    Available,      //Dostępny do wypożyczenia 
    Borrowed,       //Wypożyczony
    InMaintenance,  //W naprawie
    Retired         //Wycofany z użytku
}