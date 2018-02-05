namespace QAutomation.Core.New
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFinderByAccessibilyId
    {
        TUiObject FindByAccessibilityId<TUiObject>(string accessibilityId, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindAllByAccessibilityId<TUiObject>(string accessibilityId, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
