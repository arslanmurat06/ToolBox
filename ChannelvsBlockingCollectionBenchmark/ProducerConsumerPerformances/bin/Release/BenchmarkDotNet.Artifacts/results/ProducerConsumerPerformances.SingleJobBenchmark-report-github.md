``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18362.959 (1903/May2019Update/19H1)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4180.0), X86 LegacyJIT  [AttachedDebugger]
  DefaultJob : .NET Framework 4.8 (4.8.4180.0), X86 LegacyJIT


```
|                  Method |       Mean |      Error |     StdDev |
|------------------------ |-----------:|-----------:|-----------:|
| BlockingCollectionQueue | 276.040 μs | 21.2391 μs | 60.5962 μs |
|           ChannelsQueue |   9.096 μs |  0.2078 μs |  0.6126 μs |
