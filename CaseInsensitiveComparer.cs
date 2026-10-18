using System;
using System.Collections.Generic;

namespace Day_01_G03
{
    /// <summary>
    /// Custom comparer that compares two strings ignoring upper/lower case.
    /// Used with OrderBy / ThenBy so "aPPLE" and "AbAcUs" are sorted as if they were all lowercase.
    /// </summary>
    class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
            => string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
    }
}
