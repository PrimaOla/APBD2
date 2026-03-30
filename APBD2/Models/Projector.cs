namespace APBD2.Models;

public class Projector : Equipment
{
    public int BrightnessLumens {get; set; }
    public string NativeResolution {get; set; }

    public Projectorint (id, string name, DateTime purchaseDate, decimal value, int brightnessLumens, string nativeResolution)
    : base(id, name, purchaseDate, value)
    {
        BrightnessLumens = brightnessLumens; 
        NativeResolution = nativeResolution;
    }

    public override string ToString()
    {
        return base.ToString() + $", Brightness: {BrightnessLumens} lm, Native Resoltution: {NativeResolution}";
    }
}