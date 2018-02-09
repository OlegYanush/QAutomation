namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;

    public class Frame : IFrame
    {
        public Frame() { }
        public Frame(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
