using System;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptLong : IComparable<EncryptLong>, IEquatable<EncryptLong>
    {
        private static readonly Random _RANDOM = new();

        private static readonly long _KEY = _RANDOM.Next(1, Int32.MaxValue);


        private long _0;
        private long _1;
        private long _2;

        private byte _index;

        private EncryptLong(long value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe long Get()
        {
            fixed(EncryptLong* array = &this)
            {
                return((long*) array)[_index] ^ _KEY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(long value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptLong* array = &this)
            {
                ((long*) array)[_index] = value ^ _KEY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(long value) { Set(Get() + value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(long value) { Set(Get() - value); }

        public int CompareTo(EncryptLong other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptLong other) => Get() == other.Get();

        public override bool Equals(object obj) => obj is EncryptLong other && Equals(other);

        public override int GetHashCode() => Get().GetHashCode();

        public override string ToString() => Get().ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptLong(long value) { return new EncryptLong(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long(EncryptLong d) { return d.Equals(null) ? 0 : d.Get(); }
    }
}