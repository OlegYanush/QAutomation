namespace QAutomation.Core.Interfaces.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IElement
    {
        IElement Parent { get; }
        By By { get; set; }

        bool Displayed { get; }
        bool Enabled { get; }

        Point Location { get; }
        string Content { get; }

        string Tag { get; }
        Size Size { get; }

        string GetAttribute(string attribute);
        string GetCssValue(string property);
    }
}
