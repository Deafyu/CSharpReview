using CSharpReview;
using CSharpReview.Decoder;

namespace PayloadDecoderTests
{
    public class PaylodDecoderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestExample()
        {
            PayloadDecoder payloadDecoder = new PayloadDecoder();
            var message = await payloadDecoder.DecodePayload(Payloads.PayloadExamples.First());

            Assert.IsNotNull(message);

            Assert.Pass();
        }
    }
}