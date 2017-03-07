using System;

class FloatBinRepresent
{

    // Print hexadecimal in binary format

    static void PrintBinary(int hexDecNumber, string formatter)
    {
        int binNumber = 0;
        int temp = hexDecNumber;
        byte position = 0;
        string printStr = "";
        do
        {
            int bitSet = temp & 1;
            binNumber = (bitSet << position) | binNumber;
            temp = temp >> 1;
            position += 1;
            printStr = bitSet + printStr;
        } while (temp != 0);
        for (int k = 0; k < 8 - position; k++)
        {
            printStr = "0" + printStr;
        }
        Console.Write(formatter, printStr);
    }

    static void Main( )
    {
        Console.WriteLine("Show internal binary representation of given float number in IEEE 754 format\n");
        string formatter;

        float floatNumber=-27.25f;

        byte[] byteArray = BitConverter.GetBytes(floatNumber);

        int mantissa = byteArray[2];
        mantissa &= 0x7f;
        mantissa <<= 16;
        mantissa |= (byteArray[1] << 8);
        mantissa |= byteArray[0];

        int exponent = byteArray[2] >> 7;
        exponent=exponent|((byteArray[3]&0x7f)<<1);
        int sign = byteArray[3]>>7;

        Console.WriteLine("{0}{1,10}{2,18}{3,25}\n", "float number", "sign", "exponent", "mantissa");
        Console.Write("{0}", floatNumber);

        Console.Write("{0,14}",sign); ;

        formatter = "{0,20:D}";
        PrintBinary(exponent, formatter);
       
        formatter = "{0,36:D}";
        PrintBinary(mantissa, formatter);

        Console.WriteLine();
        Console.WriteLine();
    }
}
