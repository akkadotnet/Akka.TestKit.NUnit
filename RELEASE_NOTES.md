## [1.4.39] / July 22 2022
 - Support for Akka 1.4.39
 - Support for NUnit 3.13.3
 - Now targets `netstandard2.0`
 - All `TestKit` classes now implement `[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]` which guarantees a unique `ActorSystem` instance per-run. All previous TestKit hacks needed to support this are now removed. See https://github.com/akkadotnet/Akka.TestKit.NUnit/issues/44 for details.