//-----------------------------------------------------------------------
// <copyright file="NUnitAssertions.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2016 Typesafe Inc. <http://www.typesafe.com>
//     Copyright (C) 2013-2016 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Akka.TestKit.NUnit
{
    /// <summary>
    /// Assertions for NUnit
    /// </summary>
    public class NUnitAssertions  : ITestKitAssertions
    {
        public void Fail(string format = "", params object[] args)
        {
            Assert.Fail(NUnitAssertBase.ConvertMessageWithArgs(format, args));
        }

        public void AssertTrue(bool condition, string format = "", params object[] args)
        {
            Assert.That(condition, Is.True, NUnitAssertBase.ConvertMessageWithArgs(format, args));
        }

        public void AssertFalse(bool condition, string format = "", params object[] args)
        {
            Assert.That(condition, Is.False, NUnitAssertBase.ConvertMessageWithArgs(format, args));
        }

        public void AssertEqual<T>(T expected, T actual, string format = "", params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected), NUnitAssertBase.ConvertMessageWithArgs(format, args));
        }

        public void AssertEqual<T>(T expected, T actual, Func<T, T, bool> comparer, string format = "", params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected).Using<T>(comparer), NUnitAssertBase.ConvertMessageWithArgs(format, args));
        }

        public Exception AssertThrows(Action action)
        {
            return Assert.Throws<Exception>(() => action());
        }

        public TException AssertThrows<TException>(Action action) where TException : Exception
        {
            return Assert.Throws<TException>(() => action());
        }

        public Task<Exception> AssertThrowsAsync(Func<Task> action)
        {
            return Task.FromResult(Assert.ThrowsAsync<Exception>(() => action()));
        }

        public Task<TException> AssertThrowsAsync<TException>(Func<Task> action) where TException : Exception
        {
            return Task.FromResult(Assert.ThrowsAsync<TException>(() => action()));
        }

        /// <remarks>
        /// This class only exists to allow us to call <c>NUnit.Framework.AssertBase.ConvertMessageWithArgs</c>.
        /// As of NUnit 4.3.1, this method is declared <c>protected</c> and thus cannot be called directly.
        /// See https://github.com/nunit/nunit/blob/4.3.1/src/NUnitFramework/framework/AssertBase.cs#L10-L14.
        /// </remarks>
        private sealed class NUnitAssertBase : AssertBase
        {
            public new static string ConvertMessageWithArgs(string message, object[] args) =>
                AssertBase.ConvertMessageWithArgs(message, args);
        }
    }
}
