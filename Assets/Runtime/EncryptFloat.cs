using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Encrypt
{
    public struct EncryptFloat : IComparable<EncryptFloat>, IEquatable<EncryptFloat>
    {
        private static readonly Random _RANDOM = new();
        private static readonly uint   _KEY    = (uint) _RANDOM.Next(1, int.MaxValue);

        private uint _0;
        private uint _1;
        private uint _2;

        private byte _index;

        private EncryptFloat(float value)
        {
            _0 = _1 = _2 = 0;

            _index = (byte) _RANDOM.Next(0, 3);

            Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe float Get()
        {
            fixed(EncryptFloat* array = &this)
            {
                uint value = ((uint*) array)[_index] ^ _KEY;

                var bytes = BitConverter.GetBytes(value);
                return BitConverter.ToSingle(bytes, 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Set(float value)
        {
            if(++_index == 3)
            {
                _index = 0;
            }

            fixed(EncryptFloat* array = &this)
            {
                var bytes   = BitConverter.GetBytes(value);
                var encrypt = BitConverter.ToUInt32(bytes, 0) ^ _KEY;
                ((uint*) array)[_index] = encrypt;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(float value) { Set(Get() + value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(float value) { Set(Get() - value); }
        
        public int CompareTo(EncryptFloat other) => Get().CompareTo(other.Get());

        public bool Equals(EncryptFloat other) => Math.Abs(Get() - other.Get()) < float.Epsilon;

        public override bool Equals(object obj) => obj is EncryptFloat other && Equals(other);

        public override int GetHashCode() => Get().GetHashCode();

        public override string ToString() => Get().ToString(CultureInfo.InvariantCulture);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EncryptFloat(float value) { return new EncryptFloat(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float(EncryptFloat d) { return d.Equals(null) ? 0 : d.Get(); }
    }
}