using Encrypt;
using NUnit.Framework;

namespace Tests
{
    public class EncryptUShortTest
    {
        [Test]
        public void Encrypt2UShort()
        {
            EncryptUShort encrypt = 0;

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
        public void UShort2Encrypt()
        {
            ushort        value   = 0;
            EncryptUShort encrypt = value;

            Assert.IsTrue(encrypt == value);
        }

        [Test]
        public void EncryptEquals()
        {
            EncryptUShort one   = 0;
            EncryptUShort other = 0;

            Assert.IsTrue(one == other);
        }
    }
}