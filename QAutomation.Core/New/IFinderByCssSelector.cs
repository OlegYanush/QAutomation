namespace QAutomation.Core.New
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IFinderByCssSelector
    {
        TUiObject FindByCssSelector<TUiObject>(string cssSelector, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindAllByCssSelector<TUiObject>(string cssSelector, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
