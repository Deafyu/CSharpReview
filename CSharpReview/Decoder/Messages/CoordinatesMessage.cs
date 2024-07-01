namespace CSharpReview.Decoder.Messages;

public class CoordinatesMessage : MessageAbstract
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string LatitudeDirection { get; set; }
    public string LongitudeDirection { get; set; }

    public override string ToString()
    {
        return
            $"Sequence ID: {SequenceId}, Message Type: {MessageType} \n" +
            $"Latitude: {Latitude}, Longitude: {Longitude} \n" +
            $"Latitude Direction: {LatitudeDirection}, Longitude Direction: {LongitudeDirection}\n";
    }
}