using System;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptSByte : IComparable<EncryptSByte>, IEquatable<EncryptSByte>
    {
        private static readonly Random _RANDOM = new();
        private static readonly sbyte  _KEY    = (sbyte) _RANDOM.Next(1, sbyte.MaxValue);

        private sbyte _0;
        private sbyte _1;
        private sbyte _2;

        private byte _index;

        private EncryptSByte(sbyte value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe sbyte Get()
        {
            fixed(EncryptSByte* array = &this)
            {
                return(sbyte) (((sbyte*) array)[_index] ^ _KEY);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(sbyte value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptSByte* array = &this)
            {
                ((sbyte*) array)[_index] = (sbyte) (value ^ _KEY);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(sbyte value) { Set((sbyte) (Get() + value)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(sbyte value) { Set((sbyte) (Get() - value)); }

        public int CompareTo(EncryptSByte other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptSByte other) => Get() == other.Get();

        public override bool Equals(object obj) => obj is EncryptInt other && Equals(other);

        public override int GetHashCode() => Get();

        public override string ToString() => Get().ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptSByte(sbyte value) { return new EncryptSByte(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte(EncryptSByte d) { return d.Equals(null) ? default : d.Get(); }
    }
}