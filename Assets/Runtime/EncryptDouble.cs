using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptDouble : IComparable<EncryptDouble>, IEquatable<EncryptDouble>
    {
        private static readonly Random _RANDOM = new();

        private static readonly ulong _KEY = (ulong) _RANDOM.Next(1, int.MaxValue);

        private ulong _0;
        private ulong _1;
        private ulong _2;

        private byte _index;

        private EncryptDouble(double value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe double Get()
        {
            fixed(EncryptDouble* array = &this)
            {
                var value = ((ulong*) array)[_index] ^ _KEY;
                var bytes = BitConverter.GetBytes(value);
                return BitConverter.ToDouble(bytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(double value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptDouble* array = &this)
            {
                var   bytes   = BitConverter.GetBytes(value);
                ulong encrypt = BitConverter.ToUInt64(bytes, 0);
                ((ulong*) array)[_index] = encrypt ^ _KEY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(double value) { Set(Get() + value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(double value) { Set(Get() - value); }

        public int CompareTo(EncryptDouble other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptDouble other) => Math.Abs(Get() - other.Get()) < Double.Epsilon;

        public override bool Equals(object obj) => obj is EncryptDouble other && Equals(other);

        public override int GetHashCode() => Get().GetHashCode();

        public override string ToString() => Get().ToString(CultureInfo.InvariantCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptDouble(int value) { return new EncryptDouble(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double(EncryptDouble d) { return d.Equals(null) ? 0 : d.Get(); }
    }
}