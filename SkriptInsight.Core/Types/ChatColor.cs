using System;
using System.Linq;
using JetBrains.Annotations;
using SkriptInsight.Core.Extensions;
using SkriptInsight.Core.Types.Attributes;

namespace SkriptInsight.Core.Types
{
    [PublicAPI]
    [Flags]
    public enum ChatColor
    {
        [PatternAlias("light cyan", "light aqua", "turquoise", "turquois", "light blue")]
        [ChatColorInfo('b', "#55FFFF")]
        Aqua = 1,

        [PatternAlias("black")] [ChatColorInfo('0', "#000000")]
        Black = 1 << 1,

        [PatternAlias("light blue", "indigo", "brown")] [ChatColorInfo('9', "#5555FF")]
        Blue = 1 << 2,

        [PatternAlias("cyan", "aqua", "dark cyan", "dark aqua", "dark turquoise", "dark turquois")]
        [ChatColorInfo('3', "#00AAAA")]
        DarkAqua = 1 << 3,

        [PatternAlias("dark blue", "blue")] [ChatColorInfo('1', "#0000AA")]
        DarkBlue = 1 << 4,

        [PatternAlias("dark grey", "dark gray")] [ChatColorInfo('8', "#555555")]
        DarkGray = 1 << 5,

        [PatternAlias("green", "dark green")] [ChatColorInfo('2', "#00AA00")]
        DarkGreen = 1 << 6,

        [PatternAlias("purple", "dark purple")] [ChatColorInfo('5', "#AA00AA")]
        DarkPurple = 1 << 7,

        [PatternAlias("red", "dark red")] [ChatColorInfo('4', "#AA0000")]
        DarkRed = 1 << 8,

        [PatternAlias("gold", "orange", "dark yellow")] [ChatColorInfo('6', "#FFAA00")]
        Gold = 1 << 9,

        [PatternAlias("grey", "gray", "light grey", "light gray", "silver")] [ChatColorInfo('7', "#AAAAAA")]
        Gray = 1 << 10,


        [PatternAlias("green", "light green", "lime", "lime green")] [ChatColorInfo('a', "#55FF55")]
        Green = 1 << 11,


        [PatternAlias("magenta", "light purple")] [ChatColorInfo('d', "#FF55FF")]
        LightPurple = 1 << 12,


        [PatternAlias("pink", "light red")] [ChatColorInfo('c', "#FF5555")]
        Red = 1 << 13,


        [PatternAlias("white")] [ChatColorInfo('f', "#FFFFFF")]
        White = 1 << 14,


        [PatternAlias("yellow", "light yellow")] [ChatColorInfo('e', "#FFFF55")]
        Yellow = 1 << 15,


        [PatternAlias("bold")] [ChatColorInfo('l', "", "", "bold")]
        Bold = 1 << 16,


        [PatternAlias("italic", "italics")] [ChatColorInfo('o', "", "", "italic")]
        Italic = 1 << 17,


        [PatternAlias("magic", "obfuscated")] [ChatColorInfo('k')]
        Magic = 1 << 18,


        [PatternAlias("reset", "r")] [ChatColorInfo('r')]
        Reset = 1 << 19,


        [PatternAlias("strikethrough", "strike")] [ChatColorInfo('m', "", "", "", "line-through")]
        StrikeThrough = 1 << 20,


        [PatternAlias("italic", "italics")] [ChatColorInfo('n', "", "", "", "underline")]
        Underline = 1 << 21
    }

    [UsedImplicitly]
    public static class ChatColorExtensions
    {
        public static bool HasFlagFast(this ChatColor value, ChatColor flag)
        {
            return (value & flag) != 0;
        }

        public static bool IsBold(this ChatColor value)
        {
            return value.HasFlagFast(ChatColor.Bold);
        }

        public static bool IsItalic(this ChatColor value)
        {
            return value.HasFlagFast(ChatColor.Italic);
        }

        public static bool IsReset(this ChatColor value)
        {
            return value.HasFlagFast(ChatColor.Reset);
        }

        public static bool IsStrikeThrough(this ChatColor value)
        {
            return value.HasFlagFast(ChatColor.StrikeThrough);
        }

        public static bool IsUnderline(this ChatColor value)
        {
            return value.HasFlagFast(ChatColor.Underline);
        }

        public static bool IsMagic(this ChatColor value)
        {
            return value.HasFlagFast(ChatColor.Magic);
        }

        public static ChatColor[] GetColors(this ChatColor value)
        {
            return Enum.GetValues(typeof(ChatColor)).OfType<ChatColor>().Where(c => value.HasFlagFast(c)).ToArray();
        }

        public static bool IsSpecialFormatting(this ChatColor value)
        {
            return value.IsReset() || value.IsBold() || value.IsItalic() || value.IsStrikeThrough() ||
                   value.IsUnderline() || value.IsMagic();
        }

        public static char GetChar(this ChatColor value)
        {
            return value.GetAttributeOfType<ChatColorInfoAttribute>()?.Character ?? char.MinValue;
        }

        public static string GetColorRgb(this ChatColor value)
        {
            return value.GetAttributeOfType<ChatColorInfoAttribute>()?.Color;
        }

        public static string GetTextDecoration(this ChatColor value)
        {
            return value.GetAttributeOfType<ChatColorInfoAttribute>()?.TextDecoration;
        }

        public static string GetFontWeight(this ChatColor value)
        {
            return value.GetAttributeOfType<ChatColorInfoAttribute>()?.FontWeight;
        }
    }
}