## [1.5.24] / June 11 2024
 - [Bump Akka.TestKit to 1.5.24](https://github.com/akkadotnet/akka.net/releases/tag/1.5.24)
 - [Bump NUnit3TestAdapter to 4.5.0](https://github.com/akkadotnet/Akka.TestKit.NUnit/pull/97)
 - [Bump NUnit to 3.14.0](https://github.com/akkadotnet/Akka.TestKit.NUnit/pull/116)

## [1.4.39] / July 22 2022
 - Support for Akka 1.4.39
 - Support for NUnit 3.13.3
 - Now targets `netstandard2.0`
 - All `TestKit` classes now implement `[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]` which guarantees a unique `ActorSystem` instance per-run. All previous TestKit hacks needed to support this are now removed. See https://github.com/akkadotnet/Akka.TestKit.NUnit/issues/44 for details.