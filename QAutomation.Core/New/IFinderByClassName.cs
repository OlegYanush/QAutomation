namespace QAutomation.Core.New
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFinderByClassName
    {
        TUiObject FindByClassName<TUiObject>(string className, double timeoutInSec = -1) where TUiObject : IUiObject;

        IEnumerable<TUiObject> FindAllByClassName<TUiObject>(string className, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
