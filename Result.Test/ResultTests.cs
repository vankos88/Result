using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Result.Test
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void ResultSuccessTest()
        {
            var result = Result.Success();

            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(result.HasSuccessMessage);
            Assert.IsFalse(result.HasFailMessage);
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public void ResultSuccessWithMessageTest()
        {
            var result = Result.Success("success message");

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.HasSuccessMessage);
            Assert.IsFalse(result.HasFailMessage);
            Assert.IsFalse(result.HasException);
            Assert.AreEqual(result.SuccessMessage, "success message");
        }

        [TestMethod]
        public void ResultFailTest()
        {
            var result = Result.Fail();

            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(result.HasSuccessMessage);
            Assert.IsFalse(result.HasFailMessage);
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public void ResultFailWithMessageTest()
        {
            var result = Result.Fail("Natash, mbi vse yronili");

            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(result.HasSuccessMessage);
            Assert.IsTrue(result.HasFailMessage);
            Assert.IsFalse(result.HasException);
            Assert.AreEqual(result.FailMessage, "Natash, mbi vse yronili");
        }

        [TestMethod]
        public void ResultFailWithExceptionTest()
        {
            var result = Result.Fail(new Exception("exception text"));

            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(result.HasSuccessMessage);
            Assert.IsFalse(result.HasFailMessage);
            Assert.IsTrue(result.HasException);
            Assert.IsNotNull(result.Exception);
            Assert.AreEqual(result.Exception.Message, "exception text");
        }

        [TestMethod]
        public void ResultFailWithExceptionAndMessageTest()
        {
            var result = Result.Fail(new Exception("exception text"), "Natash, mbi vse yronili");

            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(result.HasSuccessMessage);
            Assert.IsTrue(result.HasFailMessage);
            Assert.IsTrue(result.HasException);
            Assert.AreEqual(result.FailMessage, "Natash, mbi vse yronili");
            Assert.IsNotNull(result.Exception);
            Assert.AreEqual(result.Exception.Message, "exception text");
        }
    }
}
