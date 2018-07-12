using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VkAnalyzer.Enums
{
    public class CommonMaps
    {
        public static readonly Dictionary<int, Color> ChartColorMap = new Dictionary<int, Color>
        {
            { 0, System.Drawing.ColorTranslator.FromHtml("#5DA5DA") },
            { 1, System.Drawing.ColorTranslator.FromHtml("#FAA43A") },
            { 2, System.Drawing.ColorTranslator.FromHtml("#60BD68") },
            { 3, System.Drawing.ColorTranslator.FromHtml("#F17CB0") },
            { 4, System.Drawing.ColorTranslator.FromHtml("#B2912F") },
            { 5, System.Drawing.ColorTranslator.FromHtml("#B276B2") },
            { 6, System.Drawing.ColorTranslator.FromHtml("#DECF3F") },
            { 7, System.Drawing.ColorTranslator.FromHtml("#F15854") },
            { 8, System.Drawing.ColorTranslator.FromHtml("#4D4D4D") }
        };

        public static readonly Dictionary<string, string> UserParametersMap = new Dictionary<string, string>
        {
            { "Пол", "Sex" },
            { "Город", "City" },
            { "Возраст", "BDate" },
            { "Семейное Положение", "Family" },
            { "Наличие Детей", "HasChilds" },
            { "Указан Мобильный", "MobileExists" },
            { "Онлайн", "IsOnline" }
        };
    }
}
