using Encrypt;
using NUnit.Framework;

namespace Tests
{
    public class EncryptULongTest
    {
        [Test]
        public void Encrypt2ULong()
        {
            EncryptULong encrypt = 0;

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
        public void ULong2Encrypt()
        {
            ulong        value   = 0;
            EncryptULong encrypt = value;

            Assert.IsTrue(encrypt == value);
        }

        [Test]
        public void EncryptEquals()
        {
            EncryptULong one   = 0;
            EncryptULong other = 0;

            Assert.IsTrue(one == other);
        }
    }
}