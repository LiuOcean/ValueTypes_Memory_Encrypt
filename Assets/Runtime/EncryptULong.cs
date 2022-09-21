using System;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptULong : IComparable<EncryptULong>, IEquatable<EncryptULong>
    {
        private static readonly Random _RANDOM = new();

        private static readonly ulong _KEY = (ulong) _RANDOM.Next(1, Int32.MaxValue);


        private ulong _0;
        private ulong _1;
        private ulong _2;

        private byte _index;

        private EncryptULong(ulong value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ulong Get()
        {
            fixed(EncryptULong* array = &this)
            {
                return((ulong*) array)[_index] ^ _KEY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(ulong value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptULong* array = &this)
            {
                ((ulong*) array)[_index] = value ^ _KEY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(ulong value) { Set(Get() + value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(ulong value) { Set(Get() - value); }

        public int CompareTo(EncryptULong other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptULong other) => Get() == other.Get();

        public override bool Equals(object obj) => obj is EncryptULong other && Equals(other);

        public override int GetHashCode() => Get().GetHashCode();

        public override string ToString() => Get().ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptULong(ulong value) { return new EncryptULong(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong(EncryptULong d) { return d.Equals(null) ? 0 : d.Get(); }
    }
}