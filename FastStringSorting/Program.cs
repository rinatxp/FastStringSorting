using BenchmarkDotNet.Attributes;
using FastStringSorting;

_ = BenchmarkDotNet.Running.BenchmarkRunner.Run<StringCompareClasses>();

[BaselineColumn]
public class StringCompareClasses
{
    IComparer<string> cmpDefault = new ComparerDefault(),
                        cmpFast = new ComparerFast();

    [Benchmark(Baseline = true)]
    public void Method1()
    {
        Array.Copy(SourceStrings.DefaultStrings,
                    SourceStrings.Strings1,
                    SourceStrings.Strings1.Length);

        Array.Sort<string>(SourceStrings.Strings1, cmpDefault);
    }

    [Benchmark]
    public void Method2()
    {
        Array.Copy(SourceStrings.DefaultStrings,
                    SourceStrings.Strings2,
                    SourceStrings.Strings2.Length);

        Array.Sort<string>(SourceStrings.Strings2, cmpFast);
    }
}