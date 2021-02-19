using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsApp.Service
{
    class CalculationService
    {
        public EspecificType Max<EspecificType>(List<EspecificType> list) where EspecificType : IComparable
        {
            EspecificType max = list[0];

            foreach (EspecificType e in list)
            {
                if (e.CompareTo(max) > 0)
                {
                    max = e;
                }
            }
            return max;
        }
    }
}
