using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillStrategy;
using static MillStrategy.Utils;

namespace MillStrategy.Tests
{
    internal static class TestOctalNumber
    {
        static void test_nooperators()
        {
            OctalNumber nr = 2;
            Debug.Assert(nr == 2);
            nr += 6;
            Debug.Assert(nr == 8);
            Debug.Assert(nr == "10");
            Debug.Assert(nr.FirstDigit == 1);
            Debug.Assert(nr.LastDigit == 0);
            Debug.Assert(nr.FirstDigit == '1');
            Debug.Assert(nr.LastDigit == '0');
            Debug.Assert(nr.FirstDigit == "1");
            Debug.Assert(nr.LastDigit == "0");
            Debug.Assert(nr[0] == 1);
            Debug.Assert(nr[1] == 0);
            nr.FirstDigit = 2;
            Debug.Assert(nr == "20");
            nr = 0;
            nr.FirstDigit = '2';
            Debug.Assert(nr == "20");
            nr = 1;
            nr.LastDigit = 2;
            Debug.Assert(nr == 2);
            nr = '2';
            Debug.Assert(nr == 2);
            Debug.Assert(OctalNumber.AreConsecutive(7, 8, 9));
            Debug.Assert(OctalNumber.AreConsecutive("10", "11", "12"));
            Debug.Assert(!OctalNumber.AreConsecutive("10", "10", "10"));
            Debug.Assert(OctalNumber.AreConsecutive(OctalNumber.DigitOptions.First, "10", "20", "30"));
            Debug.Assert(OctalNumber.AreConsecutive(OctalNumber.DigitOptions.Last, "10", "21", "32"));
            Debug.Assert(!OctalNumber.AreConsecutive(OctalNumber.DigitOptions.Last, "7", "10", "11"));
            Debug.Assert("123".Substring(0, 0) == "");
            Debug.Assert(nr.circularAdd(2) == 4);
            Debug.Assert(nr.circularAdd(6) == 0);
            nr.FirstDigit = 1;
            nr.LastDigit = '0';
            Debug.Assert(nr.circularAdd(2) == "12");
            Debug.Assert(nr.circularAdd("21") == "11");
            Debug.Assert(nr.circularSubstract("1") == "17");
            Debug.Assert(nr.circularSubstract("10") == "10");
        }
        public static void Run()
        {
            test_nooperators();
        }
    }
}
