using System;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptInt : IComparable<EncryptInt>, IEquatable<EncryptInt>
    {
        private static readonly Random _RANDOM = new();

        private static readonly int _KEY = _RANDOM.Next(1, Int32.MaxValue);

        private int _0;
        private int _1;
        private int _2;

        private byte _index;

        private EncryptInt(int value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe int Get()
        {
            fixed(EncryptInt* array = &this)
            {
                return((int*) array)[_index] ^ _KEY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(int value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptInt* array = &this)
            {
                ((int*) array)[_index] = value ^ _KEY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(int value) { Set(Get() + value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(int value) { Set(Get() - value); }

        public int CompareTo(EncryptInt other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptInt other) => Get() == other.Get();

        public override bool Equals(object obj) => obj is EncryptInt other && Equals(other);

        public override int GetHashCode() => Get();

        public override string ToString() => Get().ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptInt(int value) { return new EncryptInt(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(EncryptInt d) { return d.Equals(null) ? 0 : d.Get(); }
    }
}