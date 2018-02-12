namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Core.Enums;
    using QAutomation.Logger;

    public interface ICheckbox : IUiElement
    {
        CheckboxState GetState(ILogger log);

        void SetState(CheckboxState check, ILogger log);
    }
}
