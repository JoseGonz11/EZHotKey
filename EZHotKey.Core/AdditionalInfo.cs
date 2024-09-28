namespace EZHotKey.Core;

public class AdditionalInfo
{
    public OperatingSystem CurrentSystem { get; private set; }

    protected internal void SetCurrentSysten(OperatingSystem system)
    {
        CurrentSystem = system;
    }
}