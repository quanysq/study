namespace AttributeSample
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TestAttribute: Attribute
    {
        public string DisplayName { get; set; }
     
        public int DisplayWidth { get; set; }

        public TestAttribute(string displayName, int displayWidth)
        {
            DisplayName = displayName;
            DisplayWidth = displayWidth;
        }
    }
}
