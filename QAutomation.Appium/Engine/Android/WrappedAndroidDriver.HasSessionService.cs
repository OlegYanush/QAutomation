namespace QAutomation.Appium.Engine.Android
{
    using QAutomation.Core.Interfaces.Mobile;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class WrappedAndroidDriver : IHasSessionService
    {
        public string GetAutomationName(ILogger log)
        {
            throw new NotImplementedException();
        }

        public string GetPlatformName(ILogger log)
        {
            throw new NotImplementedException();
        }

        public object GetSessionDetail(string detail, ILogger log)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetSessionDetails(ILogger log)
        {
            log?.DEBUG("Get session details.");

            try
            {
                var details = _nativeDriver.SessionDetails;
                log?.INFO("Geting session details successfully completed.");

                return details;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting session details.";
                log?.DEBUG(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
