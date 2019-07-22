using System;
using System.Linq;

namespace Microsoft.DSX.ProjectTemplate.Data.Utilities
{
    public static class RandomFactory
    {
        private static readonly Random _random = new Random();
        private static readonly object _randLock = new object();

        // https://en.wikipedia.org/wiki/List_of_fictional_Microsoft_companies
        private static readonly string[] _companyNames =
        {
            "A. Datum Corporation",
            "AdventureWorks Cycles",
            "Alpine Ski House",
            "Awesome Computers",
            "Baldwin Museum of Science",
            "Blue Yonder Airlines",
            "City Power & Light",
            "Coho Vineyard & Winery",
            "Consolidated Messenger",
            "Contoso Ltd.",
            "cpandl.com",
            "CRONUS",
            "Electronic, Inc.",
            "Fabrikam, Inc.",
            "Fourth Coffee",
            "FusionTomo",
            "Graphic Design Institute",
            "Humongous Insurance",
            "ItExamWorld.com",
            "LitWare Inc.",
            "Lucerne Publishing",
            "Margie's Travel",
            "Northridge Video",
            "Northwind Traders",
            "Olympia",
            "Parnell Aerospace",
            "ProseWare, Inc.",
            "School of Fine Art",
            "Southbridge Video",
            "TailSpin Toys",
            "Tasmanian Traders",
            "The Phone Company",
            "Trey Research Inc.",
            "The Volcano Coffee Company",
            "WingTip Toys",
            "Wide World Importers",
            "Woodgrove Bank"
        };

        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private static readonly string[] _codeNames = new string[]
            {
                "Algiers",
                "Amazon",
                "Amsterdam",
                "Annapurna",
                "Aphrodite",
                "Apollo",
                "Ares",
                "Artemis",
                "Athens",
                "Baltis",
                "Berlin",
                "Bogota",
                "Calabar",
                "Casablanca",
                "Caspian",
                "Centaurus",
                "Ceres",
                "Demeter",
                "Dresden",
                "Erie",
                "Eris",
                "Everest",
                "Flora",
                "Geneva",
                "Giza",
                "Hades",
                "Halifax",
                "Helsinki",
                "Hestia",
                "Huron",
                "Jakar",
                "Janus",
                "Juno",
                "Jupiter",
                "K2",
                "Kathmandu",
                "Keflavik",
                "Kingston",
                "Kyoto",
                "Ladoga",
                "Luxor",
                "Malawi",
                "Manila",
                "Maribor",
                "Mars",
                "Melbourne",
                "Mercury",
                "Minerva",
                "Mississippi",
                "Nazret",
                "Neptune",
                "Nile",
                "Orcus",
                "Perth",
                "Pomona",
                "Poseidon",
                "Ridder",
                "Rift",
                "Riga",
                "Saimaa",
                "Sarajevo",
                "Sarband",
                "Saturn",
                "Seine",
                "Sol",
                "Sparta",
                "Strand",
                "Tallinn",
                "Tellus",
                "Themes",
                "Toledo",
                "Trevi",
                "Turku",
                "Venus",
                "Vesta",
                "Vilnius",
                "Visby",
                "Vulcan",
                "Westeros",
                "Zeus"
            };

        public static int GetInteger(int inclusiveMin, int exclusiveMax)
        {
            lock (_randLock)
            {
                return _random.Next(inclusiveMin, exclusiveMax);
            }
        }

        public static string GetAlphanumericString(int length)
        {
            lock (_randLock)
            {
                return new string(Enumerable.Repeat(_chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
            }
        }

        public static bool GetBoolean()
        {
            lock (_randLock)
            {
                return _random.Next(0, 2) == 1;
            }
        }

        public static string GetCodeName()
        {
            lock (_randLock)
            {
                return _codeNames[_random.Next(_codeNames.Length)];
            }
        }

        public static string GetCompanyName()
        {
            lock (_randLock)
            {
                return _companyNames[_random.Next(0, _companyNames.Length)];
            }
        }
    }
}
