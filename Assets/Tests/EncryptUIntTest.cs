using Encrypt;
using NUnit.Framework;

namespace Tests
{
    public class EncryptUIntTest
    {
        [Test]
        public void Encrypt2UInt()
        {
            EncryptUInt encrypt = 0;

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
        public void UInt2Encrypt()
        {
            uint        value   = 0;
            EncryptUInt encrypt = value;

            Assert.IsTrue(encrypt == value);
        }

        [Test]
        public void EncryptEquals()
        {
            EncryptUInt one   = 0;
            EncryptUInt other = 0;

            Assert.IsTrue(one == other);
        }
    }
}