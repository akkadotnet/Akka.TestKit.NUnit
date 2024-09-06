//-----------------------------------------------------------------------
// <copyright file="NUnitAssertions.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2016 Typesafe Inc. <http://www.typesafe.com>
//     Copyright (C) 2013-2016 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;

#pragma warning disable NUnit2050 // NUnit 4 no longer supports string.Format specification

namespace Akka.TestKit.NUnit3
{
    /// <summary>
    /// Assertions for NUnit
    /// </summary>
    public class NUnitAssertions  : ITestKitAssertions
    {
        
        public void Fail(string format = "", params object[] args)
        {
            Assert.Fail(format, args);
        }

        public void AssertTrue(bool condition, string format = "", params object[] args)
        {
            Assert.That(condition, Is.True, format, args);
        }

        public void AssertFalse(bool condition, string format = "", params object[] args)
        {
            Assert.That(condition, Is.False, format, args);
        }

        public void AssertEqual<T>(T expected, T actual, string format = "", params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected), format, args);
        }

        public void AssertEqual<T>(T expected, T actual, Func<T, T, bool> comparer, string format = "", params object[] args)
        {
            Assert.That(actual, Is.EqualTo(expected).Using<T>(comparer), format, args);
        }
    }
}
