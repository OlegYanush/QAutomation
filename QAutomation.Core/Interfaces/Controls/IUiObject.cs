namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Logger;
    using System.Drawing;

    public interface IUiObject : IUiObjectFinder
    {
        string Name { get; set; }

        string Tag { get; }
        string Content { get; }

        bool Displayed { get; }
        bool Enabled { get; }

        Size Size { get; }
        Point Location { get; }

        void Focus(ILogger log);
        string GetAttribute(string attribute, ILogger log);
    }
}
