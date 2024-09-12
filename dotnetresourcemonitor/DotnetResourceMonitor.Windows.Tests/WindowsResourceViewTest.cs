using DotnetResourceMonitor.Core;
using DotnetResourceMonitor.Interface;

namespace DotnetResourceMonitor.Windows.Tests;

public class WindowsResourceViewTest
{
    public WindowsResourceViewTest()
    {
        Locator.CurrentMutable.Register(() => new WindowsResourceManager(), typeof(IResourceManager), Consts.Windows);
    }

    [Fact]
    public void GetGaugeCpu()
    {
        var manager = Locator.Current.GetService<IResourceManager>(Consts.Windows);
    }

    [Fact]
    public void GetGaugeRam()
    {

    }

    [Fact]
    public void GetGaugeDisks()
    {

    }

    [Fact]
    public void GetGaugeGpus()
    {

    }

    [Fact]
    public void GetGaugeEtherNets()
    {

    }
}