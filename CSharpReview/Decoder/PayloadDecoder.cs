using CSharpReview.Decoder.Messages;

namespace CSharpReview.Decoder
{
    public class PayloadDecoder
    {
        /// <summary>
        /// Input parameter and returned value should stay as is
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<MessageAbstract> DecodePayload(byte[] payload)
        {
            if (payload is null || payload.Length < PayloadConstants.MinimumLength)
            {
                throw new InvalidPayloadException("Payload length is invalid");
            }

            int sequenceId = (payload[0] << 8) | payload[1];

            int messageType = payload[2];

            switch (messageType)
            {
                case 1:
                    return await DecodeCoordinateMessage(payload, sequenceId, messageType);
                case 2:
                    return await DecodeSpeedMessage(payload, sequenceId, messageType);
                case 3:
                    return await DecodeMileageMessage(payload, sequenceId, messageType);
                default:
                    throw new InvalidPayloadException("Invalid message type");
            }
        }

        private async Task<MessageAbstract> DecodeCoordinateMessage(byte[] payload, int sequenceId, int messageType)
        {
            double latitude = (((UInt32)payload[3]) << 24) |
                              (((UInt32)payload[4]) << 16) |
                              (((UInt32)payload[5]) << 8)  |
                              (((UInt32)payload[6]));
            latitude /= 100000.0;
            double longitude = (((UInt32)payload[7]) << 24) |
                              (((UInt32)payload[8]) << 16) |
                              (((UInt32)payload[9]) << 8)  |
                              (((UInt32)payload[10]));
            longitude /= 100000.0;
        
            string latitudeDirection = payload[11] == 0 ? "North" :
                payload[11] == 1 ? "South" : throw new InvalidPayloadException("Invalid direction");
            string longitudeDirection = payload[12] == 0 ? "East" :
                payload[12] == 1 ? "West" : throw new InvalidPayloadException("Invalid direction");
            return await Task.FromResult(new CoordinatesMessage
            {
                SequenceId = sequenceId,
                MessageType = messageType,
                Latitude = latitude,
                Longitude = longitude,
                LatitudeDirection = latitudeDirection,
                LongitudeDirection = longitudeDirection
            });
        }

        private async Task<MessageAbstract> DecodeSpeedMessage(byte[] payload, int sequenceId, int messageType)
        {
            int speed = payload[3];
            string unit = payload[4] == 0 ? "MPH" :
                payload[4] == 1 ? "KPH" : throw new InvalidPayloadException("Invalid unit");

            return await Task.FromResult(new SpeedMessage()
            {
                SequenceId = sequenceId,
                MessageType = messageType,
                Speed = speed,
                Unit = unit
            });
        }


        private async Task<MessageAbstract> DecodeMileageMessage(byte[] payload, int sequenceId, int messageType)
        {       
            var ipBytes = new byte[payload.Length];
            payload.CopyTo(ipBytes, 0);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(ipBytes);

            long mileage = BitConverter.ToUInt32(ipBytes, 0);
            return await Task.FromResult(new MileageMessage()
            {
                SequenceId = sequenceId,
                MessageType = messageType,
                Mileage = mileage
            });
        }
    }
}