// See https://aka.ms/new-console-template for more information

using System.Reflection.PortableExecutable;

class Program
{
    static void Main(string[] args)
    {
        // 1. Array Initialization

        // cara 1:
        char[] vowels = new char[5];
        vowels[0] = 'a';
        vowels[1] = 'i';
        vowels[2] = 'u';
        vowels[3] = 'e';
        vowels[4] = 'o';

        // cara 2:
        // char[] vowels = new char[] { 'a', 'i', 'u', 'e', 'o' };

        // cara 3:
        // char[] vowels = { 'a', 'i', 'u', 'e', 'o' };

        // cara 4:
        // char[] vowels = ['a', 'i', 'u', 'e', 'o' ];

        System.Console.WriteLine(vowels[1]);

        for(int i = 0; i<vowels.Length; i++)
        {
            System.Console.WriteLine(vowels[i]);
        }


        // 2. Indices
        char lastElement  = vowels[^1];   // 'o'
        char secondToLast = vowels[^2];  // 'e'

        // 3. Ranges
        char[] firstTwo =  vowels[..2];    // Elements from index 0 up to (but not including) index 2: 'a', 'i'
        char[] lastThree = vowels[2..];    // Elements from index 2 to the end: 'u', 'e', 'o'
        char[] middleOne = vowels[2..3];   // Elements from index 2 up to (not including) index 3: 'u'

        char[] lastTwo = vowels[^2..]; // Elements from second-to-last to the end: 'e', 'o'

        Range firstTwoRange = 0..2;
        firstTwo = vowels[firstTwoRange]; // 'a', 'i'

        // 4. Multidimensional Arrays
        
        // Rectangular Arrays
        // cara 1:
        int[,] matrix = new int[3, 3]; 

        for (int i = 0; i < matrix.GetLength(0); i++) // Iterate through rows
            for (int j = 0; j < matrix.GetLength(1); j++) // Iterate through columns
                matrix[i, j] = i * 3 + j;

        // cara 2: 
        int[,] matrix = new int[,]
            {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8}
            };


        // Jagged Arrays --> a different length, creating a "jagged" structure
        // cara 1:
        int[][] matrix = new int[3][];
        
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new int[3]; // Create inner array (e.g., each inner array has a length of 3)
            for (int j = 0; j < matrix[i].Length; j++)
            matrix[i][j] = i * 3 + j;
        }
        // cara 2:
        int[][] matrix = new int[][]
            {
            new int[] {0, 1, 2},
            new int[] {3, 4, 5},
            new int[] {6, 7, 8, 9} // This inner array has a different length
            };


    }


}