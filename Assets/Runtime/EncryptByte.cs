using System;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptByte : IComparable<EncryptByte>, IEquatable<EncryptByte>
    {
        private static readonly Random _RANDOM = new();
        private static readonly byte   _KEY    = (byte) _RANDOM.Next(1, Int32.MaxValue);

        private byte _0;
        private byte _1;
        private byte _2;

        private byte _index;

        private EncryptByte(byte value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe byte Get()
        {
            fixed(EncryptByte* array = &this)
            {
                return(byte) (((byte*) array)[_index] ^ _KEY);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(byte value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptByte* array = &this)
            {
                ((byte*) array)[_index] = (byte) (value ^ _KEY);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(byte value) { Set((byte) (Get() + value)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(byte value) { Set((byte) (Get() - value)); }

        public int CompareTo(EncryptByte other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptByte other) => Get() == other.Get();

        public override bool Equals(object obj) => obj is EncryptInt other && Equals(other);

        public override int GetHashCode() => Get();

        public override string ToString() => Get().ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptByte(byte value) { return new EncryptByte(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte(EncryptByte d) { return d.Equals(null) ? default : d.Get(); }
    }
}