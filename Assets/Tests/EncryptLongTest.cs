using System.Collections.Generic;
using Encrypt;
using NUnit.Framework;

namespace Tests
{
    public class EncryptLongTest
    {
        [Test]
        public void Encrypt2Long()
        {
            EncryptLong encrypt = 0;

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
        public void Long2Encrypt()
        {
            int         value   = 0;
            EncryptLong encrypt = value;

            Assert.IsTrue(encrypt == value);
        }

        [Test]
        public void EncryptEquals()
        {
            EncryptLong one   = 0;
            EncryptLong other = 0;

            Assert.IsTrue(one == other);
        }
    }
}