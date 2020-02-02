using AutoFixture.xUnit2.AutoMoq;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Moq;
using Xunit;
using xUnitWithAutoFixture.Api.Providers;

namespace xUnitWithAutoFixture.Api.UnitTests.Providers
{
    public class AcceptLanguageProviderTests
    {
        [Theory, AutoMockData]
        public void GetAcceptedLocales_ReturnsCorrectAcceptedLocaleList(
            [Frozen] IHttpContextAccessor httpContextAccessor,
            AcceptLanguageProvider sut)
        {
            // arrange
            var defaultHttpContext = new DefaultHttpContext();
            defaultHttpContext.Request.Headers[HeaderNames.AcceptLanguage] = "en-NZ,en;q=0.9,zh-CN;q=0.8,zh;q=0.7,en-GB;q=0.6,en-US;q=0.5";
            Mock.Get(httpContextAccessor)
                .Setup(x => x.HttpContext)
                .Returns(defaultHttpContext);

            // act
            var acceptedLocales = sut.GetAcceptedLocales();

            // assert
            acceptedLocales.Should()
                .BeEquivalentTo("en-nz", "en", "zh-cn", "zh", "en-gb", "en-us");
        }
    }
}
