using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillStrategy
{
    public class Utils
    {
        public class OctalNumber
        {
            public OctalNumber() { }
            public OctalNumber(int value) { Value = value; }
            public OctalNumber(string repr) { Repr = repr; }
            public OctalNumber(char ch) { Repr = Convert.ToString(ch); }

            public string Repr { get; set; } = "0";
            public int Value { get => Convert.ToInt32(Repr, 8); set => Repr = Convert.ToString(value, 8); }
            public int Length { get => Repr.Length; }

            public OctalNumber this[int pos]
            {
                get
                {
                    if (pos < 0)
                        throw new FieldAccessException(String.Format("Pozitia {0} este invalida!", pos));
                    if (pos >= Repr.Length)
                        return new OctalNumber(0);
                    return new OctalNumber(Repr[pos]);
                }
            }
            public OctalNumber FirstDigit
            {
                get => new OctalNumber(Repr[0]);
                set
                {
                    if(Repr.Length > 1) Repr = value.Repr[0] + Repr.Substring(1);
                    else Repr = value.Repr + Repr;
                }
            }
            public OctalNumber LastDigit
            {
                get => new OctalNumber(Repr.Last());
                set
                {
                    Repr = Repr.Substring(0, Repr.Length - 1) + value.Repr.Last();
                    
                }
            }

            public static bool AreConsecutive(params OctalNumber[] nrs)
            {
                for (int i = 0; i < nrs.Length - 1; ++i)
                    if (nrs[i] + 1 != nrs[i + 1])
                        return false;
                return true;
            }
            public static bool AreConsecutive(Func<OctalNumber, OctalNumber> digitOptions, params OctalNumber[] nrs)
            {
                for(int i=0;i<nrs.Length;++i)
                    nrs[i] = digitOptions(nrs[i]);
                return AreConsecutive(nrs);
            }

            public bool IsEven { get => Value % 2 != 0; }
            public bool IsOdd { get => !IsEven; }

            // enums
            public static class DigitOptions
            {
                public static OctalNumber First(OctalNumber nr) => nr.FirstDigit;
                public static OctalNumber Last(OctalNumber nr) => nr.LastDigit;
            }

            // equality operators
            public static bool operator ==(OctalNumber number1, OctalNumber number2) => number1.Repr == number2.Repr;
            public static bool operator !=(OctalNumber number1, OctalNumber number2) => !(number1.Repr == number2.Repr);
            public static bool operator ==(OctalNumber number1, string number2) => number1.Repr == number2;
            public static bool operator !=(OctalNumber number1, string number2) => !(number1.Repr == number2);

            // comparing operators
            public static bool operator <(OctalNumber number1, OctalNumber number2) => number1.Value < number2.Value;
            public static bool operator >(OctalNumber number1, OctalNumber number2) => number1.Value > number2.Value;
            public static bool operator <=(OctalNumber number1, OctalNumber number2) => number1.Value <= number2.Value;
            public static bool operator >=(OctalNumber number1, OctalNumber number2) => number1.Value >= number2.Value;

            // binary operators
            public static OctalNumber operator +(OctalNumber number1, OctalNumber number2) => new OctalNumber(number1.Value + number2.Value);
            public static OctalNumber operator -(OctalNumber number1, OctalNumber number2) => new OctalNumber(number1.Value - number2.Value);
            public static OctalNumber operator *(OctalNumber number1, OctalNumber number2) => new OctalNumber(number1.Value * number2.Value);
            public static OctalNumber operator /(OctalNumber number1, OctalNumber number2) => new OctalNumber(number1.Value / number2.Value);
            public OctalNumber circularAdd(OctalNumber other)
            {
                string prefix = Repr.Substring(0, Repr.Length - 1);
                OctalNumber lastdigit = LastDigit + other.LastDigit;
                return new OctalNumber(prefix + lastdigit.Repr.Last());
            }
            public OctalNumber circularSubstract(OctalNumber other)
            {
                string prefix = Repr.Substring(0, Repr.Length - 1);
                OctalNumber lastdigit = (this - other);
                return new OctalNumber(prefix + lastdigit.Repr.Last());
            }

            // conversion operators
            public static implicit operator int(OctalNumber v) => v.Value;
            public static implicit operator string(OctalNumber v) => v.Repr;
            public static implicit operator OctalNumber(int v) => new OctalNumber(v);
            public static implicit operator OctalNumber(string v) => new OctalNumber(v);
            public static implicit operator OctalNumber(char v) => new OctalNumber(v);

            public override string ToString() => Repr;
        }

    }
}
