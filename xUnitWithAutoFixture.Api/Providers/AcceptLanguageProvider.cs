using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using xUnitWithAutoFixture.Common.Providers;

namespace xUnitWithAutoFixture.Api.Providers
{
    public class AcceptLanguageProvider : IAcceptLanguageProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AcceptLanguageProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public IEnumerable<string> GetAcceptedLocales()
        {
            var acceptLanguage = _httpContextAccessor.HttpContext.Request.GetTypedHeaders().AcceptLanguage;
            return acceptLanguage?.OrderByDescending(x => x.Quality.GetValueOrDefault(1)).Select(x => x.Value.ToString().Trim().ToLower());
        }
    }
}
