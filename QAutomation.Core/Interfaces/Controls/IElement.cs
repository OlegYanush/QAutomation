namespace QAutomation.Core.Interfaces.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IElement
    {
        string GetAttribute(string attribute);
        string GetCssValue(string property);

        string Tag { get; }
        string Content { get; }
    }
}
