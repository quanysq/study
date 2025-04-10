using BenchmarkDotNet.Running;
using BenchmarkSample;

// 运行 BenchmarkTest 里标记为 Benchmark 的方法，比较它们的性能
var summary = BenchmarkRunner.Run<BenchmarkTest>();
Console.WriteLine(summary);
