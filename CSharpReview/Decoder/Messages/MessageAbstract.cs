using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpReview.Decoder.Messages
{
    public abstract class MessageAbstract
    {
        public int SequenceId { get; set; }
        public int MessageType { get; set; }
        
        public override string ToString()
        {
            return
                $"Sequence ID: {SequenceId}, Message Type: {MessageType}";
        }
    }
}
