using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L1
{
    /// <summary>
    /// Container class that holds the "Table"
    /// </summary>
    public class Container
    {
        // Array to know which sign is at a specifc point
        private string[,] point_Array = new string[22, 72];
        // Array to know which points are painted 
        // and to know the limits of table
        private bool[,] used_Array = new bool[22, 72];
        private int N { get; set; } // row number
        private int M { get; set; } // column number

        public Container(int n, int m)
        {
            this.N = n;
            this.M = m;

            SetAllBlank();
            SetAllFalse();
        }

        // Makes a starting "Empty" table
        public void SetAllBlank()
        {
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 72; j++)
                {     
                    if(i == 0 && j == 0)
                    {
                        point_Array[i, j] = " ";
                    }

                    // Infomration line for rows
                    if (i == 0 && j != 0)
                    {
                        point_Array[i, j] = Convert.ToString(j);
                    }

                    // Infomration line for columns
                    if (i != 0 && j == 0)
                    {
                        point_Array[i, j] = Convert.ToString(i);
                    }

                    // "." - empty point
                    if(i != 0 && j != 0)
                    {
                        point_Array[i, j] = ".";
                    }
                }
            }
        }

        // Sets every point to blank - "Not painted"
        public void SetAllFalse()
        {
            for (int i = 1; i <= this.N; i++)
            {
                for (int j = 1; j <= this.M; j++)
                {
                    this.used_Array[i, j] = false;
                }
            }
        }

        /// <summary>
        /// Used to get an array element
        /// </summary>
        /// <param name="x"> row number </param>
        /// <param name="y"> column number </param>
        /// <returns> the string element of an array </returns>
        public string Get_Point(int x, int y)
        {
            return this.point_Array[x, y];
        }

        /// <summary>
        /// Gets the bool value of specific point
        /// </summary>
        /// <param name="x"> row number </param>
        /// <param name="y"> column number </param>
        /// <returns> bool value of point </returns>
        public bool Get_Bool(int x, int y)
        {
            return this.used_Array[x, y];
        }

        /// <summary>
        /// Sets a new string value for a point
        /// </summary>
        /// <param name="x"> row number </param>
        /// <param name="y"> column number </param>
        /// <param name="sign"> new string sign </param>
        public void Set_String(int x, int y, string sign)
        {
            this.point_Array[x, y] = sign;
        }

        /// <summary>
        /// Sets a new bool value for a point
        /// </summary>
        /// <param name="x"> row number </param>
        /// <param name="y"> column number </param>
        /// <param name="sign"> new bool sign </param>
        public void Set_Bool(int x, int y, bool sign)
        {
            this.used_Array[x, y] = sign;
        }

        // Returns the number of rows
        public int GetRowCount()
        {
            return this.N;
        }

        // Returns the number of columns
        public int GetColumnCount()
        {
            return this.M;
        }
    }
}