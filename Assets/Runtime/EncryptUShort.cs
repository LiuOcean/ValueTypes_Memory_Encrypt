using System;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptUShort : IComparable<EncryptUShort>, IEquatable<EncryptUShort>
    {
        private static readonly Random _RANDOM = new();
        private static readonly ushort  _KEY    = (ushort) _RANDOM.Next(1, ushort.MaxValue);

        private ushort _0;
        private ushort _1;
        private ushort _2;

        private byte _index;

        private EncryptUShort(ushort value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe ushort Get()
        {
            fixed(EncryptUShort* array = &this)
            {
                return(ushort) (((ushort*) array)[_index] ^ _KEY);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(ushort value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptUShort* array = &this)
            {
                ((ushort*) array)[_index] = (ushort) (value ^ _KEY);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(ushort value) { Set((ushort) (Get() + value)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(ushort value) { Set((ushort) (Get() - value)); }

        public int CompareTo(EncryptUShort other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptUShort other) => Get() == other.Get();

        public override bool Equals(object obj) => obj is EncryptInt other && Equals(other);

        public override int GetHashCode() => Get();

        public override string ToString() => Get().ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptUShort(ushort value) { return new EncryptUShort(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort(EncryptUShort d) { return d.Equals(null) ? default : d.Get(); }
    }
}