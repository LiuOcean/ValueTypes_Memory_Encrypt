using Encrypt;
using NUnit.Framework;

namespace Tests
{
    public class EncryptShortTest
    {
        [Test]
        public void Encrypt2Short()
        {
            EncryptShort encrypt = 0;

            Assert.IsTrue(encrypt == 0);

            encrypt.Set(1);
            Assert.IsTrue(encrypt == 1);

            encrypt.Set(2);
            Assert.IsTrue(encrypt == 2);

            encrypt.Set(3);
            Assert.IsTrue(encrypt == 3);

            encrypt.Set(64);
            Assert.IsTrue(encrypt == 64);
        }

        [Test]
        public void Short2Encrypt()
        {
            short        value   = 0;
            EncryptShort encrypt = value;

            Assert.IsTrue(encrypt == value);
        }

        [Test]
        public void EncryptEquals()
        {
            EncryptShort one   = 0;
            EncryptShort other = 0;

            Assert.IsTrue(one == other);
        }
    }
}