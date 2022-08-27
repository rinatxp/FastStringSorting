using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStringSorting
{
    internal class ComparerFast : IComparer<string>
    {
        public unsafe int Compare(string x, string y)
        {
            #region first chars

            int x1 = 0, y1 = 0, i;

            while ((x[x1] | ' ') >= 'a' && (x[x1] | ' ') <= 'z')
            {
                x1++;
            }
            while ((y[y1] | ' ') >= 'a' && (y[y1] | ' ') <= 'z')
            {
                y1++;
            }

            for (i = 0; i < x1 && i < y1; i++)
            {
                if ((x[i] | ' ') != (y[i] | ' '))
                {
                    return (x[i] | ' ') - (y[i] | ' ');
                }
                if (x[i] != y[i])
                {
                    return y[i] - x[i];
                }
            }

            if (x1 != y1)
            {
                return x1 - y1;
            }
            #endregion
            ////////////////
            #region first digits

            int d1X = 0, d1Y = 0,
                div = 0, div2 = 0, dlenX = 0, dlenY = 0;

            for (i = x1; i < x.Length; i++)
            {
                if (x[i] >= '0' && x[i] <= '9')
                {
                    d1X = d1X * 10 + (x[i] - '0');
                    div *= 10;
                    dlenX++;
                }
                else if (x[i] == '.' || x[i] == ',')
                {
                    div = 1;
                }
                else
                {
                    break;
                }
            }

            for (i = y1; i < y.Length; i++)
            {
                if (y[i] >= '0' && y[i] <= '9')
                {
                    d1Y = d1Y * 10 + (y[i] - '0');
                    div2 *= 10;
                    dlenY++;
                }
                else if (y[i] == '.' || y[i] == ',')
                {
                    div2 = 1;
                }
                else
                {
                    break;
                }
            }

            d1X *= div2 & ((1 - div2) >> 31) | 1 & (~(1 - div2) >> 31);
            d1Y *= div & ((1 - div) >> 31) | 1 & (~(1 - div) >> 31);

            if (d1X != d1Y)
            {
                return d1X - d1Y;
            }

            #endregion

            #region second digits

            int dlenX2 = 0,
                dlenY2 = 0;
            d1X = d1Y = 0;
            div = x1 + dlenX + 1;

            if (x[div] == ';' ||
                x[div] == ':' ||
                x[div] == '-')
            {
                dlenX2++;

                for (i = div + 1; i < x.Length && x[i] >= '0' && x[i] <= '9'; i++)
                {
                    d1X = d1X * 10 + (x[i] - '0');
                    dlenX2++;
                }
            }

            div = y1 + dlenY + 1;
            if (y[div] == ';' ||
                y[div] == ':' ||
                y[div] == '-')
            {
                dlenY2++;

                for (i = div + 1; i < y.Length && y[i] >= '0' && y[i] <= '9'; i++)
                {
                    d1Y = d1Y * 10 + (y[i] - '0');
                    dlenY2++;
                }
            }

            if (dlenX2 == 0 && dlenY2 != 0)
            {
                return -1;
            }
            else if (dlenX2 != 0 && dlenY2 == 0)
            {
                return 1;
            }
            else if (d1X != d1Y)
            {
                return d1X - d1Y;
            }

            #endregion
            ///////////
            #region second chars

            x1 = dlenX2 = x1 + dlenX + dlenX2;
            y1 = dlenY2 = y1 + dlenY + dlenY2;

            while (++x1 < x.Length && ++y1 < y.Length)
            {
                if (x[x1] != y[y1])
                {
                    return x[x1] - y[y1];
                }
            }

            return (x.Length - dlenX2) - (y.Length - dlenY2);
            #endregion
        }
    }
}
