using ExchangeRates.Core.Entities;
using ExchangeRates.Core.Extensions;
using ExchangeRates.Services.Implementations;
using ExchangeRates.Services.Interfaces;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.Tests
{
    public class ObjectExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ObjectExtensions_IsNotNull_Success()
        {
            string value = "test";
            var result = value.IsNotNull();

            Assert.IsTrue(result);
        }

        [Test]
        public void ObjectExtensions_IsNotNull_Fail()
        {
            string value = null;
            var result = value.IsNotNull();

            Assert.IsFalse(result);
        }

        [Test]
        public void ObjectExtensions_IsValid_Success()
        {
            KeyValuePair<string, double> value = new KeyValuePair<string, double>("test", 1);
            var result = value.IsValid();

            Assert.IsTrue(result);
        }

        [Test]
        public void ObjectExtensions_IsValid_NullKey_Fail()
        {
            KeyValuePair<string, double> value = new KeyValuePair<string, double>(null, 1);
            var result = value.IsValid();

            Assert.IsFalse(result);
        }

        [Test]
        public void ObjectExtensions_IsValid_ZeroDouble_Fail()
        {
            KeyValuePair<string, double> value = new KeyValuePair<string, double>("test", 0);
            var result = value.IsValid();

            Assert.IsFalse(result);
        }

        [Test]
        public void ObjectExtensions_IsValid_NegativeDouble_Fail()
        {
            KeyValuePair<string, double> value = new KeyValuePair<string, double>("test", -1);
            var result = value.IsValid();

            Assert.IsFalse(result);
        }
    }
}