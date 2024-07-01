namespace CSharpReview.Decoder.Messages;

public class SpeedMessage : MessageAbstract
{
    public int Speed { get; set; }
    public string Unit { get; set; }

    public override string ToString()
    {
        return
            $"Sequence ID: {SequenceId}, Message Type: {MessageType} \n" +
            $"Speed: {Speed}, Unit: {Unit}\n";
    }
}