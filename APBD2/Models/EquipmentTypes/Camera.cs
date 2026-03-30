namespace APBD2.Models.EquipmentTypes;

public class Camera : Equipment
{
    public int ResolutionMp {get; set; }
    public bool HasVideoRecording {get; set; }

    public Camera(int id, string name, DateTime purchaseDate, decimal value, int resolutionMp, bool hasVideoRecording)
    : base(id, name, purchaseDate, value)
    {
        ResolutionMp = resolutionMp;
        HasVideoRecording = hasVideoRecording;
    }

    public override string ToString()
    {
        return base.ToString() + $", Resolution: {ResolutionMp} MP, Video: {(HasVideoRecording ? "Yes" : "No")}";
    }
}