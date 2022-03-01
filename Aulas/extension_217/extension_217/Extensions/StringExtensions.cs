namespace extension_217.Extensions {
    static class StringExtensions {
        public static string Cut(this string str, int count) {
            if (str.Length <= count)
                return str;
            else
                return $"{str.Substring(0, count)}...";

        }

    }
}
