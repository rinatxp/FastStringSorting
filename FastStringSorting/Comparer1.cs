using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStringSorting
{
    internal class ComparerDefault : IComparer<string>
    {
        private static readonly char[] seps = { ';', ':', '-' };

        public int Compare(string x, string y)
        {
            #region first letters

            string firstLettersX = string.Join("", x.TakeWhile(t => char.IsLetter(t))),
                    firstLettersY = string.Join("", y.TakeWhile(t => char.IsLetter(t)));

            if (firstLettersX != firstLettersY)
            {
                return string.Compare(firstLettersX, firstLettersY, StringComparison.CurrentCulture);
            }

            #endregion

            #region first digits

            double dX = double.Parse(string.Join("", x.Split(seps)[0]
                                            .Where(w => !char.IsLetter(w)))
                                            .Replace('.', ',')),
                   dY = double.Parse(string.Join("", y.Split(seps)[0]
                                            .Where(w => !char.IsLetter(w)))
                                            .Replace('.', ','));

            if (dX < dY) return -1;
            else if (dX > dY) return 1;

            #endregion

            #region last digits

            int? iX = null, iY = null;
            try
            {
                iX = int.Parse(string.Join("", x.Split(seps)[1]
                                                .Where(w => char.IsDigit(w))));
            }
            catch { }
            try
            {
                iY = int.Parse(string.Join("", y.Split(seps)[1]
                                                .Where(w => char.IsDigit(w))));
            }
            catch { }

            if (iX == null && iY != null)
            {
                return -1;
            }
            else if (iX != null && iY == null)
            {
                return 1;
            }
            else if (iX != iY)
            {
                return (iX - iY).Value;
            }

            #endregion

            #region last letters

            string lastLettersX = string.Join("", x.Split(seps)[1]
                                                    .Where(w => char.IsLetter(w))),
                    lastLettersY = string.Join("", y.Split(seps)[1]
                                                    .Where(w => char.IsLetter(w)));

            return string.Compare(lastLettersX, lastLettersY, StringComparison.Ordinal);

            #endregion
        }
    }
}