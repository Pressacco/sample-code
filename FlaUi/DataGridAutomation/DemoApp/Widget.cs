using System;

namespace DemoApp
{
    public class Widget
    {
        public Widget(string key)
        {
            this.Key = key ?? throw new ArgumentNullException(nameof(key));
        }
        public string Key { get; init; }
    }
}
