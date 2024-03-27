//-----------------------------------------------------------------------
// <copyright file="NUnitAssertions.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2016 Typesafe Inc. <http://www.typesafe.com>
//     Copyright (C) 2013-2016 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Akka.TestKit.NUnit
{
    /// <summary>
    /// Assertions for NUnit
    /// </summary>
    public class NUnitAssertions  : ITestKitAssertions
    {
        
        public void Fail(string format = "", params object[] args)
        {
            ClassicAssert.Fail(format, args);
        }

        public void AssertTrue(bool condition, string format = "", params object[] args)
        {
            ClassicAssert.IsTrue(condition, format, args);
        }

        public void AssertFalse(bool condition, string format = "", params object[] args)
        {
            ClassicAssert.IsFalse(condition, format, args);
        }

        public void AssertEqual<T>(T expected, T actual, string format = "", params object[] args)
        {
            ClassicAssert.AreEqual(expected, actual, format, args);
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