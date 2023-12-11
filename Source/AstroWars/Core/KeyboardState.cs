using System.Collections.Immutable;

namespace AstroWars;

public class KeyboardState
{
    readonly bool[] Current = new bool[(int)Enum.GetValues<KeyboardCode>().Max()+1];

    public void Set   (KeyboardCode code, bool value)
    {
        Current[(int)code] = value;
    }
    public bool IsUp  (KeyboardCode code)
    {
        return !Current[(int)code];
    }
    public bool IsDown(KeyboardCode code)
    {
        return Current[(int)code];
    }
}