using Akka.Actor;
using NUnit.Framework;

namespace Akka.TestKit.NUnit.Tests;

[TestFixture]
public class Bugfix44Spec : TestKit
{
    // need to have the DefaultConfig for the TestKit with this ActorSystem
    public Bugfix44Spec() : base(ActorSystem.Create("Foo", TestKit.DefaultConfig))
    {
        
    }
    
    private static ActorSystem _previousSystem;
    
    [Test, Order(1)]
    public void Should_use_provided_ActorSystem()
    {
        _previousSystem = Sys;
        Assertions.AssertEqual("Foo",Sys.Name);
    }
    
    [Test, Order(2)]
    public void Should_use_provided_ActorSystem_again()
    {
        // Technically this will be a second, different ActorSystem but the names should be the same
        Assertions.AssertEqual("Foo",Sys.Name);
        Assertions.AssertFalse(_previousSystem.Equals(Sys));
    }
}