using Encrypt;
using NUnit.Framework;

namespace Tests
{
    public class EncryptByteTest
    {
        [Test]
        public void Encrypt2Byte()
        {
            EncryptByte encrypt = 0;

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
        public void Byte2Encrypt()
        {
            byte        value   = 0;
            EncryptByte encrypt = value;

            Assert.IsTrue(encrypt == value);
        }

        [Test]
        public void EncryptEquals()
        {
            EncryptByte one   = 0;
            EncryptByte other = 0;

            Assert.IsTrue(one == other);
        }
    }
}