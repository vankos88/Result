using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Result.Test
{
    [TestClass]
    public class ResultOfTTests
    {
        [TestMethod]
        public void ResultSuccessTest()
        {
            var result = Result<string>.Success();

            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(result.HasSuccessMessage);
            Assert.IsFalse(result.HasData);
            Assert.IsFalse(result.HasFailMessage);
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public void ResultSuccessWithMessageTest()
        {
            var result = Result<string>.Success("success message");

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.HasSuccessMessage);
            Assert.IsFalse(result.HasData);
            Assert.IsFalse(result.HasFailMessage);
            Assert.IsFalse(result.HasException);
            Assert.AreEqual(result.SuccessMessage, "success message");
        }

        [TestMethod]
        public void ResultSuccessWithDataTest()
        {
            var result = Result<string>.Success(data:"data");

            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(result.HasSuccessMessage);
            Assert.IsTrue(result.HasData);
            Assert.IsFalse(result.HasFailMessage);
            Assert.IsFalse(result.HasException);
            Assert.AreEqual(result.Data, "data");
        }

        [TestMethod]
        public void ResultSuccessWithDataAndMessageTest()
        {
            var result = Result<string>.Success("success message", "data");

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.HasSuccessMessage);
            Assert.IsTrue(result.HasData);
            Assert.IsFalse(result.HasFailMessage);
            Assert.IsFalse(result.HasException);
            Assert.AreEqual(result.Data, "data");
            Assert.AreEqual(result.SuccessMessage, "success message");
        }

        [TestMethod]
        public void ResultFailWithDataAndMessageTest()
        {
            var result = Result<string>.Fail("Natash, mbi vse yronili", "data");

            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(result.HasSuccessMessage);
            Assert.IsTrue(result.HasFailMessage);
            Assert.IsFalse(result.HasException);
            Assert.AreEqual(result.Data, "data");
            Assert.AreEqual(result.FailMessage, "Natash, mbi vse yronili");
        }
    }
}
