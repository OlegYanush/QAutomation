namespace QAutomation.Core.Interfaces.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMobileElement : IElement
    {
        IMobileElement FindElementByPlatformSelector(string selector);
        IEnumerable<IMobileElement> FindElementsByPlatformSelector(string selector);
    }
}
