namespace BlazorApp.Data;

public class Converter
{
    public double Input { get; set; }
    public UnitType UnitType { get; set; }
    public Volume InputVolume { get; set; }
    public Volume ResultVolume { get; set; }
    public Time InputTime { get; set; }
    public Time ResultTime { get; set; }
    public double Result { get; set; }
}
