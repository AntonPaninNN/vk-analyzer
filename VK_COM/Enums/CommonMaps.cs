using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Constants;

namespace VK_COM.Enums
{
    public class CommonMaps
    {
        public static readonly Dictionary<string, string> RelationMap = new Dictionary<string, string>
        {
            { "0", "нет данных" },
            { "1", "не женат/не замужем" },
            { "2", "есть друг/есть подруга" },
            { "3", "помолвлен/помолвлена" },
            { "4", "женат/замужем" },
            { "5", "всё сложно" },
            { "6", "в активном поиске" },
            { "7", "влюблён/влюблена" }
        };

        public static readonly Dictionary<string, string> HasMobileMap = new Dictionary<string, string>
        {
            { "0", XmlConstants.FALSE_VALUE_RU },
            { "1", XmlConstants.TRUE_VALUE_RU }
        };

        public static readonly Dictionary<string, string> OnlineMap = new Dictionary<string, string>
        {
            { "0", XmlConstants.FALSE_VALUE_RU },
            { "1", XmlConstants.TRUE_VALUE_RU }
        };

        public static readonly Dictionary<string, string> SexMap = new Dictionary<string, string>
        {
            { "0", "нет данных" },
            { "1", "Женский" },
            { "2", "Мужской" }
        };
    }
}
