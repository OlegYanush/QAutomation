namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUiObject : IUiObjectFinder
    {
        string Name { get; set; }

        string Tag { get; }
        string Content { get; }

        bool Displayed { get; }
        bool Enabled { get; }

        Size Size { get; }
        Point Position { get; }

        string GetAttribute(string attribute);
    }
}
