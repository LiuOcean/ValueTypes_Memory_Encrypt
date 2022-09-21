using Encrypt;
using NUnit.Framework;

namespace Tests
{
    public class EncryptFloatTest
    {
        [Test]
        public void Encrypt2Float()
        {
            EncryptFloat encrypt = 0;

            Assert.IsTrue(encrypt == 0);

            encrypt.Set(1);
            Assert.IsTrue(encrypt == 1);

            encrypt.Set(2);
            Assert.IsTrue(encrypt == 2);

            encrypt.Set(3);
            Assert.IsTrue(encrypt == 3);

            encrypt.Set(257);
            Assert.IsTrue(encrypt == 257);
        }

        [Test]
        public void Float2Encrypt()
        {
            int        value   = 0;
            EncryptFloat encrypt = value;

            Assert.IsTrue(encrypt == value);
        }

        [Test]
        public void EncryptEquals()
        {
            EncryptFloat one   = 0;
            EncryptFloat other = 0;

            Assert.IsTrue(one == other);
        }
    }
}