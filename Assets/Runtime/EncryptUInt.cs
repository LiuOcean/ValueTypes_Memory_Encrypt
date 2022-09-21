using System;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptUInt : IComparable<EncryptUInt>, IEquatable<EncryptUInt>
    {
        private static readonly Random _RANDOM = new();

        private static readonly uint _KEY = (uint) _RANDOM.Next(1, int.MaxValue);

        private uint _0;
        private uint _1;
        private uint _2;

        private byte _index;

        private EncryptUInt(uint value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe uint Get()
        {
            fixed(EncryptUInt* array = &this)
            {
                return((uint*) array)[_index] ^ _KEY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(uint value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptUInt* array = &this)
            {
                ((uint*) array)[_index] = value ^ _KEY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(uint value) { Set(Get() + value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(uint value) { Set(Get() - value); }

        public int CompareTo(EncryptUInt other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptUInt other) => Get() == other.Get();

        public override bool Equals(object obj) => obj is EncryptUInt other && Equals(other);

        public override int GetHashCode() => Get().GetHashCode();

        public override string ToString() => Get().ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptUInt(uint value) { return new EncryptUInt(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint(EncryptUInt d) { return d.Equals(null) ? 0 : d.Get(); }
    }
}