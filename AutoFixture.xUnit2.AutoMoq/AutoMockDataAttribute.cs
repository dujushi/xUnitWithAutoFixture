using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace AutoFixture.xUnit2.AutoMoq
{
    public class AutoMockDataAttribute : AutoDataAttribute
    {
        public AutoMockDataAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization())) { }
    }
}
