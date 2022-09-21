using System.Collections.Generic;
using Encrypt;
using NUnit.Framework;

namespace Tests
{
    public class EncryptSByteTest
    {
        [Test]
        public void Encrypt2SByte()
        {
            EncryptSByte encrypt = 0;

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
        public void SByte2Encrypt()
        {
            sbyte          value   = 0;
            EncryptSByte encrypt = value;

            Assert.IsTrue(encrypt == value);
        }

        [Test]
        public void EncryptEquals()
        {
            EncryptSByte one   = 0;
            EncryptSByte other = 0;

            Assert.IsTrue(one == other);
        }
    }
}