using AutoFixture.Xunit2;

namespace AutoFixture.xUnit2.AutoMoq
{
    public class InlineAutoMockDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoMockDataAttribute(params object[] values)
            : base(new AutoMockDataAttribute(), values) { }
    }
}
