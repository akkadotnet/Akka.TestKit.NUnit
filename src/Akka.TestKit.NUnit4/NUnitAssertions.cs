//-----------------------------------------------------------------------
// <copyright file="NUnitAssertions.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2016 Typesafe Inc. <http://www.typesafe.com>
//     Copyright (C) 2013-2016 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;

namespace Akka.TestKit.NUnit4
{
    /// <summary>
    /// Assertions for NUnit
    /// </summary>
    public class NUnitAssertions : ITestKitAssertions
    {

        public void Fail(string format = "", params object[] args)
        {
            Assert.Fail(string.Format(format, args));
        }

        public void AssertTrue(bool condition, string format = "", params object[] args)
        {
            Assert.That(condition, Is.EqualTo(true), string.Format(format, args));
        }

        public void AssertFalse(bool condition, string format = "", params object[] args)
        {
            Assert.That(condition, Is.EqualTo(false), string.Format(format, args));
        }

        public void AssertEqual<T>(T expected, T actual, string format = "", params object[] args)
        {
            Assert.That(expected, Is.EqualTo(actual), string.Format(format, args));
        }

        public void AssertEqual<T>(T expected, T actual, Func<T, T, bool> comparer, string format = "", params object[] args)
        {
            if (!comparer(expected, actual))
                throw new AssertionException($"Assert.AreEqual failed. Expected [{FormatValue(expected)}]. Actual [{FormatValue(actual)}]. {string.Format(format, args)}");
        }

        private static string FormatValue<T>(T expected)
        {
            return ReferenceEquals(expected, null) ? "null" : expected.ToString();
        }
    }
}