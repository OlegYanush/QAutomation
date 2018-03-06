namespace QAutomation.Core.Enums
{
    using System;

    [Flags]
    public enum UiElementState : byte
    {
        None = 0b0000_0001,
        Present = 0b0000_0010,
        Visible = 0b0000_0100,
        Enabled = 0b0000_1000,
        Absent = 0b0001_0000,
        NotVisible = 0b0010_0000,
        Disabled = 0b0100_0000,
        Available = Present | Visible | Enabled,
        AbsentOrNotVisible = Absent | NotVisible,
    }
}
