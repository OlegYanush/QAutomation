namespace QAutomation.Core.New
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFinderByXPath
    {
        TUiObject FindByXPath<TUiObject>(string xpath, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindAllByXPath<TUiObject>(string xpath, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
