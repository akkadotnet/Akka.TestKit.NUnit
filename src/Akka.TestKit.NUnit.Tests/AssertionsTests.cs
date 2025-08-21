//-----------------------------------------------------------------------
// <copyright file="AssertionsTests.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2016 Typesafe Inc. <http://www.typesafe.com>
//     Copyright (C) 2013-2016 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Akka.Configuration;
using NUnit.Framework;

namespace Akka.TestKit.NUnit.Tests;

[Parallelizable(ParallelScope.All)]
public class AssertionsTests : TestKit
{
    private readonly NUnitAssertions _assertions;

    public AssertionsTests()
    {
        _assertions = new NUnitAssertions();
    }

    [Test]
    public void Fail_should_throw()
    {
        Assert.Throws<AssertionException>(() => _assertions.Fail());
    }

    [Test]
    public void AssertTrue_should_throw_on_false()
    {
        Assert.Throws<AssertionException>(() => _assertions.AssertTrue(false));
    }

    [Test]
    public void AssertTrue_should_succeed_on_true()
    {
        _assertions.AssertTrue(true);
    }

    [Test]
    public void AssertFalse_should_throw_on_true()
    {
        Assert.Throws<AssertionException>(() => _assertions.AssertFalse(true));
    }

    [Test]
    public void AssertFalse_should_succeed_on_false()
    {
        _assertions.AssertFalse(false);
    }

    [Test]
    public void AssertEqual_should_throw_on_not_equal()
    {
        Assert.Throws<AssertionException>(() => _assertions.AssertEqual(42, 4711));
    }

    [Test]
    public void AssertEqual_should_succeed_on_equal()
    {
        _assertions.AssertEqual(42, 42);
    }

    [Test]
    public void AssertEqualWithComparer_should_throw_on_not_equal()
    {
        Assert.Throws<AssertionException>(() => _assertions.AssertEqual(42, 1142, Comparer));
    }

    [Test]
    public void AssertEqualWithComparer_should_succeed_on_equal()
    {
        Assert.DoesNotThrow(() => _assertions.AssertEqual(42, 42, Comparer));
    }

    private static bool Comparer(int x, int y) => x == y;
    
    [TestCaseSource(nameof(_exceptionData))]
    public void AssertThrows_should_succeed_on_any_thrown_exception(Exception exception)
    {
        Assert.That(_assertions.AssertThrows(ThisThrows), Is.EqualTo(exception));
        return;

        void ThisThrows()
        {
            throw exception;
        }
    }

    [TestCaseSource(nameof(_exceptionData))]
    public async Task AssertThrows_should_succeed_on_any_thrown_exception_async(Exception exception)
    {
        await Assert.ThatAsync(() => _assertions.AssertThrowsAsync(ThisThrows), Is.EqualTo(exception));
        return;

        async Task ThisThrows()
        {
            await Task.Yield();
            throw exception;
        }
    }

    [Test]
    public void AssertThrows_should_fail_when_no_exception_was_thrown()
    {
        Assert.That(() => _assertions.AssertThrows(ThisDoesNotThrows), Throws.TypeOf(typeof(AssertionException)));
        return;

        void ThisDoesNotThrows()
        {
        }
    }

    [Test]
    public async Task AssertThrows_should_fail_when_no_exception_was_thrown_async()
    {
        await Assert.ThatAsync(() => _assertions.AssertThrowsAsync(ThisDoesNotThrows), Throws.TypeOf(typeof(AssertionException)));
        return;

        async Task ThisDoesNotThrows()
        {
            await Task.Yield();
        }
    }

    [TestCaseSource(nameof(_exceptionData))]
    public void Generic_AssertThrows_should_succeed_only_on_specific_exception(Exception exception)
    {
        if (exception is ConfigurationException ex)
        {
            Assert.That(_assertions.AssertThrows<ConfigurationException>(ThisThrows), Is.EqualTo(ex));
        }
        else
        {
            Assert.Throws<AssertionException>(() => _assertions.AssertThrows<ConfigurationException>(ThisThrows));
        }
        return;

        void ThisThrows()
        {
            throw exception;
        }
    }

    [TestCaseSource(nameof(_exceptionData))]
    public async Task Generic_AssertThrows_should_succeed_only_on_specific_exception_async(Exception exception)
    {
        if (exception is ConfigurationException ex)
        {
            await Assert.ThatAsync(() => _assertions.AssertThrowsAsync<ConfigurationException>(ThisThrows), Is.EqualTo(ex));
        }
        else
        {
            Assert.ThrowsAsync<AssertionException>(async () => await _assertions.AssertThrowsAsync<ConfigurationException>(ThisThrows));
        }
        return;

        async Task ThisThrows()
        {
            await Task.Yield();
            throw exception;
        }
    }

    [Test]
    public void Generic_AssertThrows_should_fail_when_no_exception_was_thrown()
    {
        Assert.That(() => _assertions.AssertThrows<ConfigurationException>(ThisDoesNotThrows), Throws.TypeOf(typeof(AssertionException)));
        return;

        void ThisDoesNotThrows()
        {
        }
    }

    [Test]
    public async Task Generic_AssertThrows_should_fail_when_no_exception_was_thrown_async()
    {
        await Assert.ThatAsync(() => _assertions.AssertThrowsAsync<ConfigurationException>(ThisDoesNotThrows), Throws.TypeOf(typeof(AssertionException)));
        return;

        async Task ThisDoesNotThrows()
        {
            await Task.Yield();
        }
    }

    private static object[] _exceptionData =
    {
        new object[] {new Exception("Wheee")},
        new object[] {new ConfigurationException("Wheee")},
        new object[] {new TimeoutException("Wheee")},
        new object[] {new OperationCanceledException("Wheee")},
    };
}