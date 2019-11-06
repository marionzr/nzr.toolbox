namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Constants to be used within the TollBox.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static class Constants
#endif
    {
        /// <summary>
        /// int Zero constant.
        /// </summary>
        public const int ZERO = 0;

        /// <summary>
        /// int One constant.
        /// </summary>
        public const int ONE = 1;

        /// <summary>
        /// False constant.
        /// </summary>
        public const bool FALSE = false;

        /// <summary>
        /// True constant.
        /// </summary>
        public const bool TRUE = true;

        /// <summary>
        /// Asterisk string constant.
        /// </summary>
        public const string ASTERISK = "*";

        /// <summary>
        /// Underscore string constant.
        /// </summary>
        public const string UNDERSCORE = "-";

        /// <summary>
        /// Alphabet constants.
        /// </summary>
        public static class Alphabet
        {
            /// <summary>
            /// Constant string letter a
            /// </summary>
            public const string a = "a";

            /// <summary>
            /// Constant string letter b
            /// </summary>
            public const string b = "b";

            /// <summary>
            /// Constant string letter c
            ///</summary>
            public const string c = "c";

            /// <summary>
            /// Constant string letter d
            ///</summary>
            public const string d = "d";

            /// <summary>
            /// Constant string letter e
            ///</summary>
            public const string e = "e";

            /// <summary>
            /// Constant string letter f
            ///</summary>
            public const string f = "f";

            /// <summary>
            /// Constant string letter g
            ///</summary>
            public const string g = "g";

            /// <summary>
            /// Constant string letter h
            ///</summary>
            public const string h = "h";

            /// <summary>
            /// Constant string letter i
            ///</summary>
            public const string i = "i";

            /// <summary>
            /// Constant string letter j
            ///</summary>
            public const string j = "j";

            /// <summary>
            /// Constant string letter k
            ///</summary>
            public const string k = "k";

            /// <summary>
            /// Constant string letter l
            ///</summary>
            public const string l = "l";

            /// <summary>
            /// Constant string letter m
            ///</summary>
            public const string m = "m";

            /// <summary>
            /// Constant string letter n
            ///</summary>
            public const string n = "n";

            /// <summary>
            /// Constant string letter o
            ///</summary>
            public const string o = "o";

            /// <summary>
            /// Constant string letter p
            ///</summary>
            public const string p = "p";

            /// <summary>
            /// Constant string letter q
            ///</summary>
            public const string q = "q";

            /// <summary>
            /// Constant string letter r
            ///</summary>
            public const string r = "r";

            /// <summary>
            /// Constant string letter s
            ///</summary>
            public const string s = "s";

            /// <summary>
            /// Constant string letter t
            ///</summary>
            public const string t = "t";

            /// <summary>
            /// Constant string letter u
            ///</summary>
            public const string u = "u";

            /// <summary>
            /// Constant string letter v
            ///</summary>
            public const string v = "v";

            /// <summary>
            /// Constant string letter w
            ///</summary>
            public const string w = "w";

            /// <summary>
            /// Constant string letter x
            ///</summary>
            public const string x = "x";

            /// <summary>
            /// Constant string letter y
            ///</summary>
            public const string y = "y";

            /// <summary>
            /// Constant string letter z
            ///</summary>
            public const string z = "z";

            /// <summary>
            /// Constant string letter A
            ///</summary>
            public const string A = "A";

            /// <summary>
            /// Constant string letter B
            ///</summary>
            public const string B = "B";

            /// <summary>
            /// Constant string letter C
            ///</summary>
            public const string C = "C";

            /// <summary>
            /// Constant string letter D
            ///</summary>
            public const string D = "D";

            /// <summary>
            /// Constant string letter E
            ///</summary>
            public const string E = "E";

            /// <summary>
            /// Constant string letter F
            ///</summary>
            public const string F = "F";

            /// <summary>
            /// Constant string letter G
            ///</summary>
            public const string G = "G";

            /// <summary>
            /// Constant string letter H
            ///</summary>
            public const string H = "H";

            /// <summary>
            /// Constant string letter I
            ///</summary>
            public const string I = "I";

            /// <summary>
            /// Constant string letter J
            ///</summary>
            public const string J = "J";

            /// <summary>
            /// Constant string letter K
            ///</summary>
            public const string K = "K";

            /// <summary>
            /// Constant string letter L
            ///</summary>
            public const string L = "L";

            /// <summary>
            /// Constant string letter M
            ///</summary>
            public const string M = "M";

            /// <summary>
            /// Constant string letter N
            ///</summary>
            public const string N = "N";

            /// <summary>
            /// Constant string letter O
            ///</summary>
            public const string O = "O";

            /// <summary>
            /// Constant string letter P
            ///</summary>
            public const string P = "P";

            /// <summary>
            /// Constant string letter Q
            ///</summary>
            public const string Q = "Q";

            /// <summary>
            /// Constant string letter R
            ///</summary>
            public const string R = "R";

            /// <summary>
            /// Constant string letter S
            ///</summary>
            public const string S = "S";

            /// <summary>
            /// Constant string letter T
            ///</summary>
            public const string T = "T";

            /// <summary>
            /// Constant string letter U
            ///</summary>
            public const string U = "U";

            /// <summary>
            /// Constant string letter V
            ///</summary>
            public const string V = "V";

            /// <summary>
            /// Constant string letter W
            ///</summary>
            public const string W = "W";

            /// <summary>
            /// Constant string letter X
            ///</summary>
            public const string X = "X";

            /// <summary>
            /// Constant string letter Y
            ///</summary>
            public const string Y = "Y";

            /// <summary>
            /// Constant string letter Z
            ///</summary>
            public const string Z = "Z";

        }

        /// <summary>
        /// DateTime format constants.
        /// </summary>
        public static class DateTimeFormats
        {
            /// <summary>
            ///  ddMMyy = "dd/MM/yy
            /// </summary>
            public const string ddMMyy = "dd/MM/yy";

            /// <summary>
            ///  ddMMyyyy = "dd/MM/yyyy
            /// </summary>
            public const string ddMMyyyy = "dd/MM/yyyy";

            /// <summary>
            ///  MMddyy = "MM/dd/yy
            /// </summary>
            public const string MMddyy = "MM/dd/yy";

            /// <summary>
            ///  MMddyyyy = "MM/dd/yyyy
            /// </summary>
            public const string MMddyyyy = "MM/dd/yyyy";

            /// <summary>
            ///  yyMMdd = "yy/MM/dd
            /// </summary>
            public const string yyMMdd = "yy/MM/dd";

            /// <summary>
            ///  yyyyMMdd = "yyyy/MM/dd
            /// </summary>
            public const string yyyyMMdd = "yyyy/MM/dd";

            /// <summary>
            ///  ddMMyyHHmm = "dd/MM/yy HH:mm
            /// </summary>
            public const string ddMMyyHHmm = "dd/MM/yy HH:mm";

            /// <summary>
            ///  ddMMyyyyHHmm = "dd/MM/yyyy HH:mm
            /// </summary>
            public const string ddMMyyyyHHmm = "dd/MM/yyyy HH:mm";

            /// <summary>
            ///  MMddyyHHmm = "MM/dd/yy HH:mm
            /// </summary>
            public const string MMddyyHHmm = "MM/dd/yy HH:mm";

            /// <summary>
            ///  MMddyyyyHHmm = "MM/dd/yyyy HH:mm
            /// </summary>
            public const string MMddyyyyHHmm = "MM/dd/yyyy HH:mm";

            /// <summary>
            ///  yyMMddHHmm = "yy/MM/dd HH:mm
            /// </summary>
            public const string yyMMddHHmm = "yy/MM/dd HH:mm";

            /// <summary>
            ///  yyyyMMddHHmm = "yyyy/MM/dd HH:mm
            /// </summary>
            public const string yyyyMMddHHmm = "yyyy/MM/dd HH:mm";

            /// <summary>
            ///  ddMMyyHHmmss = "dd/MM/yy HH:mm:ss
            /// </summary>
            public const string ddMMyyHHmmss = "dd/MM/yy HH:mm:ss";

            /// <summary>
            ///  ddMMyyyyHHmmss = "dd/MM/yyyy HH:mm:ss
            /// </summary>
            public const string ddMMyyyyHHmmss = "dd/MM/yyyy HH:mm:ss";

            /// <summary>
            ///  MMddyyHHmmss = "MM/dd/yy HH:mm:ss
            /// </summary>
            public const string MMddyyHHmmss = "MM/dd/yy HH:mm:ss";

            /// <summary>
            ///  MMddyyyyHHmmss = "MM/dd/yyyy HH:mm:ss
            /// </summary>
            public const string MMddyyyyHHmmss = "MM/dd/yyyy HH:mm:ss";

            /// <summary>
            ///  yyMMddHHmmss = "yy/MM/dd HH:mm:ss
            /// </summary>
            public const string yyMMddHHmmss = "yy/MM/dd HH:mm:ss";

            /// <summary>
            ///  yyyyMMddHHmmss = "yyyy/MM/dd HH:mm:ss
            /// </summary>
            public const string yyyyMMddHHmmss = "yyyy/MM/dd HH:mm:ss";

            /// <summary>
            ///  HHmm = "HH:mm
            /// </summary>
            public const string HHmm = "HH:mm";

            /// <summary>
            ///  HHmmss = "HH:mm:ss
            /// </summary>
            public const string HHmmss = "HH:mm:ss";

            /// <summary>
            ///  mmss = "mm:ss
            /// </summary>
            public const string mmss = "mm:ss";
        }

        internal static readonly string[] YES = new string[] { "Y", "Yes", "S", "Sim", "Si", "Ja", "Oui", "1", "true" };
    }
}
