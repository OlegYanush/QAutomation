namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBrowserDriverConfig : IDriverConfig
    {
        Browser Browser { get; }
        string Version { get; }
    }
}
