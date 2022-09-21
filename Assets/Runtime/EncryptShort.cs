using System;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptShort : IComparable<EncryptShort>, IEquatable<EncryptShort>
    {
        private static readonly Random _RANDOM = new();
        private static readonly short  _KEY    = (short) _RANDOM.Next(1, short.MaxValue);

        private short _0;
        private short _1;
        private short _2;

        private byte _index;

        private EncryptShort(short value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe short Get()
        {
            fixed(EncryptShort* array = &this)
            {
                return(short) (((short*) array)[_index] ^ _KEY);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(short value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptShort* array = &this)
            {
                ((short*) array)[_index] = (short) (value ^ _KEY);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(short value) { Set((short) (Get() + value)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(short value) { Set((short) (Get() - value)); }

        public int CompareTo(EncryptShort other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptShort other) => Get() == other.Get();

        public override bool Equals(object obj) => obj is EncryptInt other && Equals(other);

        public override int GetHashCode() => Get();

        public override string ToString() => Get().ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptShort(short value) { return new EncryptShort(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short(EncryptShort d) { return d.Equals(null) ? default : d.Get(); }
    }
}