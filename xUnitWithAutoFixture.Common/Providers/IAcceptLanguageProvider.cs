using System.Collections.Generic;

namespace xUnitWithAutoFixture.Common.Providers
{
    public interface IAcceptLanguageProvider
    {
        IEnumerable<string> GetAcceptedLocales();
    }
}
