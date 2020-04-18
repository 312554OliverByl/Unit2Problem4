/*
 * Oliver Byl
 * April 17, 2020
 * Unit 2 Summative (Problem J4)
 */
using System;
using System.Windows;
using System.IO;

namespace Unit2J4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                StreamReader reader = new StreamReader("input.txt");

                // Parse from input an array of char representing all flips to perform.
                char[] flips = reader.ReadLine().ToCharArray();

                /*
                 * Instead of moving numbers around inside arrays, this solution manipulates variables
                 * representing the index of the final number.
                 * 
                 * This is made much easier by the fact that the source (the number square) remains
                 * constant throughout every test, but the solution could easily be edited to be more
                 * general and work for any dataset.
                 * 
                 * This approach, compared to earlier drafts, minimizes the allocation of memory for
                 * arrays and temporary variables during the "flipping" process and is therefore much
                 * more scalable. I took this into account becuase the problem states the number of
                 * flipping operations performed could be up to 1,000,000.
                 */

                // Indicies of the numbers
                // 1 2
                // 3 4
                int oneIndex = 0;
                int twoIndex = 1;
                int threeIndex = 2;
                int fourIndex = 3;

                // Compact storage of the transformation indices go
                // through when flipped.
                // newIndex = flipH/V[oldIndex]
                int[] flipH = { 2, 3, 0, 1 };
                int[] flipV = { 1, 0, 3, 2 };

                // Iterate through all operations:
                for(int i = 0; i < flips.Length; i++)
                {
                    // Determing if flip is horizontal or vertical and run
                    // indicies through appropriate flipping array.
                    if(flips[i] == 'H')
                    {
                        oneIndex = flipH[oneIndex];
                        twoIndex = flipH[twoIndex];
                        threeIndex = flipH[threeIndex];
                        fourIndex = flipH[fourIndex];
                    }
                    else
                    {
                        oneIndex = flipV[oneIndex];
                        twoIndex = flipV[twoIndex];
                        threeIndex = flipV[threeIndex];
                        fourIndex = flipV[fourIndex];
                    }
                }

                // Assemble new array based on transformed indices.
                int[] numbers = new int[4];
                numbers[oneIndex] = 1;
                numbers[twoIndex] = 2;
                numbers[threeIndex] = 3;
                numbers[fourIndex] = 4;

                // Construct output.
                output.Content = numbers[0] + " " + numbers[1] + Environment.NewLine
                                + numbers[2] + " " + numbers[3];

                reader.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
