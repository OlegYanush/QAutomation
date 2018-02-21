namespace QAutomation.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class UiElementNotFoundException : Exception
    {
        public UiElementNotFoundException() { }

        public UiElementNotFoundException(string message) 
            : base(message) { }
      

        public UiElementNotFoundException(string message, Exception innerException) 
            : base(message, innerException) { }

        protected UiElementNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
