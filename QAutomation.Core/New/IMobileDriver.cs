using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation.Core.New
{
    public interface IMobileDriver : IUiObjectFinder, IFinderById, 
        IFinderByXPath, IFinderByClassName, IFinderByAccessibilyId, IFinderByCssSelector
    {
    }
}
