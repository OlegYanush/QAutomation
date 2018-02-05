namespace QAutomation.Core
{
    using QAutomation.Core.New;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUiObject : IUiObjectFinder
    {
        string Name { get; set; }

        string Tag { get; }
        string Content { get; }

        string GetAttribute(string attribute);
    }
}
