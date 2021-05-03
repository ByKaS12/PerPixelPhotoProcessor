using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoshop1
{
   public static class Filter
    {
        static public Image MedianaFilter(ObjectAPI pic, int a, ref Stopwatch st)
        {
            ObjectAPI pic2 = new ObjectAPI();
            pic2 = pic.Clone() as ObjectAPI;
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    
                    byte[] R = FilterMedianaArray(CreateMatrix(pic,a,i,j,'R'), a);
                    byte[] G = FilterMedianaArray(CreateMatrix(pic,a,i,j,'G'), a);
                    byte[] B = FilterMedianaArray(CreateMatrix(pic,a,i,j,'B'), a);
                    pic2.matrix[j, i].R = Math_Methods.QuickSelect_median(R);
                    pic2.matrix[j, i].G = Math_Methods.QuickSelect_median(G);
                    pic2.matrix[j, i].B = Math_Methods.QuickSelect_median(B);


                }

            }

            st.Stop();
            return pic2.ShowRGB();

        }
        static public int[,] FilterArray(int[,] array, int a)
        {
            int[,] arr = array.Clone() as int[,];
            for (int i = 0; i < (2 * a) + 1; i++)
            {
                for (int j = 0; j < (2 * a) + 1; j++)
                {
                    if(arr[i,j] == -1)
                    {
                       int index = j;
                        arr[i, j] = arr[i, (2 * a) - index];


                        
                            
                    }
                }

            }
            for (int i = 0; i < (2 * a) + 1; i++)
            {
                for (int j = 0; j < (2 * a) + 1; j++)
                {
                    if (arr[i, j] == -1)
                    {
                        int index = i;
                        arr[i, j] = arr[(2 * a) - index, j];
                        arr[i, j] = arr[(2 * a) - index, j];
                        arr[i, j] = arr[(2 * a) - index, j];



                    }
                }

            }
            

            return arr;

        }
        static public byte[] FilterMedianaArray(int[,] arr, int a)
        {
            byte[] medianaArr = new byte[(int)Math.Pow((2 * a) + 1, 2)];
            for (int i = 0; i < (2 * a) + 1; i++)
            {
                for (int j = 0; j < (2 * a) + 1; j++)
                {
                    if (arr[i, j] == -1)
                    {
                        int index = j;
                        arr[i, j] = arr[i, (2 * a) - index];




                    }
                }

            }
            int ii = 0;
            for (int i = 0; i < (2 * a) + 1; i++)
            {
                for (int j = 0; j < (2 * a) + 1; j++)
                {
                    if (arr[i, j] == -1)
                    {
                        int index = i;
                        arr[i, j] = arr[(2 * a) - index, j];
                        arr[i, j] = arr[(2 * a) - index, j];
                        arr[i, j] = arr[(2 * a) - index, j];



                    }
                    medianaArr[ii] = (byte)arr[i, j];
                    medianaArr[ii] = (byte)arr[i, j];
                    medianaArr[ii] = (byte)arr[i, j];
                    ii++;
                }

            }


            return medianaArr;

        }
        static public int[,] CreateMatrix(ObjectAPI pic, int a,int ii,int jj,char flag)
        {
            //int Size = (int)Math.Pow((2 * a) + 1, 2);
            if(flag == 'R')
            {
                int[,] Matrix = new int[(2 * a) + 1, (2 * a) + 1];
                int iii = 0;
                for (int i = ii - a; i <= ii + a; i++)
                {
                    int jjj = 0;
                    for (int j = jj - a; j <= jj + a; j++)
                    {
                        if ((j >= 0) && (i >= 0) && (j < pic.Width) && (i < pic.Height))
                        {
                            Matrix[iii, jjj] = (int)pic.matrix[j, i].R;

                        }
                        else
                        {
                            Matrix[iii, jjj] = -1;

                        }
                        jjj++;
                    }
                    iii++;
                }
                return Matrix;
            }
            if (flag == 'G')
            {
                int[,] Matrix = new int[(2 * a) + 1, (2 * a) + 1];
                int iii = 0;
                for (int i = ii - a; i <= ii + a; i++)
                {
                    int jjj = 0;
                    for (int j = jj - a; j <= jj + a; j++)
                    {
                        if ((j >= 0) && (i >= 0) && (j < pic.Width) && (i < pic.Height))
                        {
                            Matrix[iii, jjj] = (int)pic.matrix[j, i].G;

                        }
                        else
                        {
                            Matrix[iii, jjj] = -1;

                        }
                        jjj++;
                    }
                    iii++;
                }
                return Matrix;
            }
            if (flag == 'B')
            {
                int[,] Matrix = new int[(2 * a) + 1, (2 * a) + 1];
                int iii = 0;
                for (int i = ii - a; i <= ii + a; i++)
                {
                    int jjj = 0;
                    for (int j = jj - a; j <= jj + a; j++)
                    {
                        if ((j >= 0) && (i >= 0) && (j < pic.Width) && (i < pic.Height))
                        {
                            Matrix[iii, jjj] = (int)pic.matrix[j, i].B;

                        }
                        else
                        {
                            Matrix[iii, jjj] = -1;

                        }
                        jjj++;
                    }
                    iii++;
                }
                return Matrix;
            }
            return null;


        }
        static public byte GetReadyLinFilter(int[,] arr,double[,] filterMatrix,int a)
        {
            double sum = 0;
            for (int i = 0; i < (2*a)+1; i++)
            {
                double p = 1;
                for (int j = 0; j < (2 * a) + 1; j++)
                {
                    p = arr[i, j] * filterMatrix[i, j];
                    sum += p;
                }

            }
            return (byte)Math_Methods.Clamp(sum,0,255);
        }
        static public Image LinFilter(ObjectAPI pic, int a,double[,] filterMatrix, ref Stopwatch st)
        {
            ObjectAPI pic2 = new ObjectAPI();
            pic2 = pic.Clone() as ObjectAPI;
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {

                    int[,] R = FilterArray(CreateMatrix(pic, a, i, j, 'R'), a);
                    int[,] G = FilterArray(CreateMatrix(pic, a, i, j, 'G'), a);
                    int[,] B = FilterArray(CreateMatrix(pic, a, i, j, 'B'), a);
                    pic2.matrix[j, i].R = GetReadyLinFilter(R, filterMatrix,a);
                    pic2.matrix[j, i].G = GetReadyLinFilter(G, filterMatrix,a);
                    pic2.matrix[j, i].B = GetReadyLinFilter(B, filterMatrix,a);


                }

            }

            st.Stop();
            return pic2.ShowRGB();

        }
    }
}
