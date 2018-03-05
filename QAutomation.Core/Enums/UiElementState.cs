using System;

namespace QAutomation.Core.Enums
{
    public enum UiElementState : byte
    {
        None,
        Present,
        Enabled,
        Visible,
        Disabled,
        NotVisible,
        AbsentOrNotVisible,
        Available = Enabled | Visible
    }
}
