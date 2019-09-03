using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Infrastructure.Helpers.LocalizationService
{
    public static class LocalizationState
    {
        public static Locale Locale = Locale.RU;
    }

    public enum Locale
    {
        RU,
        UA
    }
}
