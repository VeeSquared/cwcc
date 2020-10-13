using System;
using System.Collections.Generic;
using System.Text;

namespace CampingWorld.Core.CustomTypes
{
    public partial class DecimalValue
    {
        private const decimal NanoFactor = 1_000_000_000;
        private long _units;
        private int _nanos;

        public DecimalValue(long units, int nanos)
        {
            _units = units;
            _nanos = nanos;
        }

        public static implicit operator decimal(DecimalValue decimalValue) => decimalValue.ToDecimal();

        public static implicit operator DecimalValue(decimal value) => FromDecimal(value);

        public decimal ToDecimal()
        {
            return _units + _nanos / NanoFactor;
        }

        public static DecimalValue FromDecimal(decimal value)
        {
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);
            return new DecimalValue(units, nanos);
        }
    }
}
