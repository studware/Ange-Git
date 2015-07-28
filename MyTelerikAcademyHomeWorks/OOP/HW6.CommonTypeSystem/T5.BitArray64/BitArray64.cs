/*  Define a class BitArray64 to hold 64 bit values inside an ulong value. 
    Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=. */

namespace T5.BitArray64
{
using System.Collections;
using System.Collections.Generic;

    class BitArray64: IEnumerable<int>
    {
        //fields
        private readonly ulong bit64Value;

        //constructor
        public BitArray64(ulong bit64Value=0)
        {
            this.bit64Value = bit64Value;
        }

        //property
        public int[] Bits
        {
            get { return this.ConvertToBits(); }
        }

        //IEnumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = this.ConvertToBits();

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];      
            }
        }

        //method  - convert ulong to 64-bit array
        private int[] ConvertToBits()
        {
            ulong value = this.bit64Value;

            int[] bits = new int[64];
            int counter = 63;

            while (value != 0)
            {
                bits[counter] = (int)value % 2;
                value/= 2;
                counter--;
            }

            do
            {
                bits[counter] = 0;
                counter--;
            } while (counter != 0);

            return bits;
        }

        //indexator
        private bool IndexChecker(int index)
        {
            if (index < 0 || index > 63)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //index to check the bit at given position
        public int this[int index]
        {
            get 
            {
                if (IndexChecker(index))
                {
                    throw new System.IndexOutOfRangeException();
                }
                int[] bits = this.ConvertToBits();

                return bits[index];
            }
        }

        //equals
        public bool Equals(BitArray64 value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }

            if(ReferenceEquals(this, value))
            {
                return true;
            }
         
            return this.bit64Value == value.bit64Value;
        }

        public override bool Equals(object obj)
        {
            BitArray64 objToBitArray64 = obj as BitArray64;
            if (objToBitArray64 == null)
            {
                return false;
            }
            return this.Equals(objToBitArray64);
        }

        //hash code
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.bit64Value.GetHashCode();
                return result;
            }
        }

        // == operator
        public static bool operator ==(BitArray64 operand1, BitArray64 operand2)
        {
            return BitArray64.Equals(operand1, operand2);
        }

        // != operator
        public static bool operator !=(BitArray64 operand1, BitArray64 operand2)
        {
            return !BitArray64.Equals(operand1, operand2);
        }
    }
}
