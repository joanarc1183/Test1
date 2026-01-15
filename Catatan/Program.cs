// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using Animals;  // Import the Animals namespace

namespace NamaProyek
{
 class Program
   {
       static void Main(string[] args)
       {
            // 1. Syntax

            // Identifiers 
            /*
            - camelCase --> parameters, local variabels, and private fields.
            - PascalCase --> all other identifiers, include classes, public methods, and properties.
            */

            // Keyword
            int myInt = 10;
            int @int = 10; // ga boleh --> int int = 10

            // Contextual keyword 
            var i = 0;
            int var = 10; // ga perlu pakai @ karena dia sbg kata kunci pada konteks tertentu

            // 2. Literal --> nilai yang bisa ditulis langsung 11, 11.8, ...
           
            // 3. Type
            int a = 11;
            double b = 11.8;
            char c = 'J';
            string s = "Hello";
            bool isActive = true;
            bool lessThan = a<b;
            object o = null;

            // 4. Punctuators --> membentuk dan membatasi struktur program
            /*
                | Punctuator | Fungsi                        |
                | ---------- | ----------------------------- |
                | `;`        | Mengakhiri statement          |
                | `{ }`      | Menentukan blok kode          |
                | `( )`      | Parameter, kondisi, ekspresi  |
                | `[ ]`      | Array, indexer                |
                | `,`        | Pemisah elemen                |
                | `.`        | Akses anggota (member access) |
            */

            double total =
                a +
                    b;
            
            Console
                .WriteLine(
                    s
                );

            // 5. Operators --> operasi terhadap 1 atau lebih operand

            // = untuk assign
            // + untuk penjumlahan
            int total = a+a;
            // - untuk pengurangan
            double selisih = b-a;
            // * untuk perkalian
            int luas = a*a;
            // / untuk pembagian
            double sisa = b/a;
            // % untuk sisa bagi
            int m = a%a;
            // ++ untuk increment
            // -- untuk decrement

            // 6. Tambahan
            s = s.ToUpper(); // Convert to UPPERCASE
            s = s.ToLower(); // Convert to lowercase
            string aString = a.ToString(); // Convert to "string"

            // 7. Custom Type
            UnitConverter feetToInchesConverter = new UnitConverter(12);

            Console.WriteLine(feetToInchesConverter.Convert(30)); // 360

            // 8. Symmetry of Predefined and Custom Types
            
            // Intinya: gaada perlakuan khusus antara tipe bawaan (predefined types) dan tipe buatan pengguna (custom types)
            // Tipe Bawaan
            int x = 10;
            string xString = x.ToString();
            // Tipe Buatan Pengguna --> kelas UnitConverter
            feetToInchesConverter = new UnitConverter(12);

            // 9. Instantiation
            // Umumnya menggunakan operator new yang memanggil constructor
            UnitConverter milesToFeetConverter = new UnitConverter(5200);

            // 10. Public dan Private
            // public: Anggota yang dapat diakses dari konteks luar kelas.
            // private: Anggota yang hanya dapat diakses di dalam kelas itu sendiri.
            
            // 11. Instance dan Static Members
            // Di Kelas Cat
            Cat cat1 = new Cat("Catty");

            // 12. Namespaces
            // Untuk mengorganisir dan mengelompokkan tipe (seperti kelas, struktur, dan antarmuka)
            // Lihat Namespaces Animals berisi Kelas Cat
            Cat cat2 = new Cat("Kathy");

            Console.WriteLine(cat1.Name);
            Console.WriteLine(cat2.Name);
            Console.WriteLine(Cat.Population);

            // 13. Storage Overhead

            // Value type 
            // memori yang digunakan hanya sebesar ukuran dari data itu sendiri
            // Lihat Struct
            Point p = new Point();
            // Total memori yang digunakan oleh instance p adalah 8 bytes (4 bytes untuk x + 4 bytes untuk y)
            /*
                - Numeric Types:
                    - Signed Integer: sbyte, short, int, long
                    - Unsigned Integer: byte, ushort, uint, ulong
                    - Real Number: float, double, decimal
                - Logical Type: bool
                - Character Type: char
            */

            // Reference Type 
            // memori dialokasikan di heap dan alokasi memori dibagi menjadi dua bagian:
            // - Reference : pointer yang menunjuk ke lokasi objek di heap. 4 bytes di sistem 32-bit dan 8 bytes di sistem 64-bit.
            // - Data Objek : Memori untuk field dan data objek itu sendiri yang diletakkan di heap. Selain ukuran field, ada juga overhead administratif yang disertakan oleh runtime .NET, yang umumnya sekitar 8 bytes atau lebih, tergantung pada platform.
            PointClass p = new PointClass();
            // Total memori yang digunakan oleh objek p adalah:
            // - 32-bit platform: 4 bytes (referensi) + 8 bytes (data objek) + 8 bytes (overhead) = 20 bytes
            // - 64-bit platform: 8 bytes (referensi) + 8 bytes (data objek) + 8 bytes (overhead) = 24 bytes
            /*
            - String Type: string
            - Object Type: object
            */


       }
   }

    // Lebih kecil memorinya, contoh: kordinat
    // Gabisa di inheritance
    struct Point
    {
        public int x;
        public int y;
    }

    // Lebih gede memorinya
    class PointClass
    {
        public int x;
        public int y;
    }

   public class UnitConverter
    {
        int ratio; // Field (Data members)

        // Constructor (Function members)
        public UnitConverter(int unitRatio)
        {
            ratio = unitRatio;
        }

        // Method (Function members)
        public int Convert(int unit)
        {
            return unit*ratio;
        }
    }

    
}

namespace Animals
{
    public class Cat
    {
        public string Name; // instance field
        public static int Population;   // static field

        // Constructor
        public Cat(string name) 
        {
            Name = name;    // assign instance Name field
            Population++;   // increment static Population field
        }
    }
}