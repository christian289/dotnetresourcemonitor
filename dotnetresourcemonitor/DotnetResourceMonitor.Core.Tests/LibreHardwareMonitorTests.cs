namespace DotnetResourceMonitor.Core.Tests;

public sealed class LibreHardwareMonitorTests
{
    public LibreHardwareMonitorTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    private readonly ITestOutputHelper output;

    [Fact]
    public void Monitor()
    {
        Computer computer = new()
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true,
            IsMemoryEnabled = true,
            IsMotherboardEnabled = true,
            IsControllerEnabled = true,
            IsNetworkEnabled = true,
            IsStorageEnabled = true
        };

        computer.Open();
        computer.Accept(new LibreHardwareMonitorModule());

        foreach (IHardware hardware in computer.Hardware)
        {
            output.WriteLine("Hardware: {0}", hardware.Name);
            
            foreach (IHardware subhardware in hardware.SubHardware)
            {
                output.WriteLine("\tSubhardware: {0}", subhardware.Name);
                
                foreach (ISensor sensor in subhardware.Sensors)
                {
                    output.WriteLine("\t\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                }
            }

            foreach (ISensor sensor in hardware.Sensors)
            {
                output.WriteLine("\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
            }
        }
        
        computer.Close();
    }
}
