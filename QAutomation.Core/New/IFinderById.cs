namespace QAutomation.Core.New
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFinderById
    {
        TUiObject FindById<TUiObject>(string id, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindAllById<TUiObject>(string id, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
