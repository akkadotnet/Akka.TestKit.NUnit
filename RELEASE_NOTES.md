## [1.5.0] / March 3 2023
- [Bump Akka.NET from 1.4.49 to 1.5.0](https://github.com/akkadotnet/akka.net/releases/tag/1.5.0)
- [Bump NUnit3TestAdapter from 4.2.1 to 4.3.1][https://github.com/akkadotnet/Akka.TestKit.NUnit/commit/591892dd6383c94bcf7c2ef7974cf1ce02165092]

## [1.4.39] / July 22 2022
 - Support for Akka 1.4.39
 - Support for NUnit 3.13.3
 - Now targets `netstandard2.0`
 - All `TestKit` classes now implement `[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]` which guarantees a unique `ActorSystem` instance per-run. All previous TestKit hacks needed to support this are now removed. See https://github.com/akkadotnet/Akka.TestKit.NUnit/issues/44 for details.