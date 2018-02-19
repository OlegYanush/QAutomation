namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Locators;
    using QAutomation.Logger;
    using System.Drawing;

    public interface IUiElement : IUiElementFinder
    {
        Locator Locator { get; }

        string Tag { get; }
        string Content { get; }

        bool Displayed { get; }
        bool Enabled { get; }

        Size Size { get; }
        Point Location { get; }

        string GetAttribute(string attribute, ILogger log);
    }
}
