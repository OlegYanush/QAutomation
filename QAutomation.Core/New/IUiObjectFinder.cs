using QAutomation.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation.Core.New
{
    public interface IUiObjectFinder
    {
        TUiObject Find<TUiObject>(Locator locator, ILogger log) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindAll<TUiObject>(Locator locator, ILogger log) where TUiObject : IUiObject;
    }
}
