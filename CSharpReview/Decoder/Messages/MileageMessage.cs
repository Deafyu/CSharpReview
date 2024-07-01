namespace CSharpReview.Decoder.Messages;

public class MileageMessage : MessageAbstract
{
    public long Mileage { get; set; }

    public override string ToString()
    {
        return
            $"Sequence ID: {SequenceId}, Message Type: {MessageType} \n" +
            $"Mileage: {Mileage}m\n";
    }
}