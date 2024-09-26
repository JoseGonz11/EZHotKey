namespace EZHotKey.Core;

public class AdditionalSystemInfo
{
    public OS CurrentSystem { get; private set; }

    protected internal void SetCurrentSysten(OS system)
    {
        CurrentSystem = system;
    }
}