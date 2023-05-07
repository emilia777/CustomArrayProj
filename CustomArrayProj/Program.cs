using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace CustomArrayProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[] { 1, 2, 3, 4, 11, 19, 21, 35 };
            CustomArrayList Project  = new CustomArrayList(ints);
        }
        class CustomArrayList
        {
            int[] array;
            int index = 0;
            int count = 0;
            int capasity = 0;
            public CustomArrayList()
            {
                capasity = 4;
                this.array = new int[capasity];
            }
            public CustomArrayList(int x)
            {
                try
                {
                    if (x < 0 || x.GetType() == typeof(int))
                    {
                        throw new Exception(" capasity<0 xeta var");
                    }
                    capasity = x;
                    this.array = new int[capasity];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public CustomArrayList(int[] array)
            {
                this.array = new int[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    this.array[i] = array[i];
                    count++;
                    capasity++;
                }
            }
            public int this[int index]
            {
                get { return array[index]; }
                set { array[index] = value; }
            }
            public int Count
            {
                get { return count; }
                set { count = value; }
            }
            public int Capasity
            {
                get { return capasity; }
                set { capasity = value; }
            }
            public int[] GetRange(int index, int count)
            {
                try
                {
                    if (index < 0 || count <= 0)
                    {
                        throw new Exception(" Parametr duzgun verilmemisdir ");
                    }
                    int[] newArray = new int[count];
                    for (int i = index, j = 0; j < count; i++, j++)
                    {
                        newArray[j] = this.array[i];
                    }
                    return newArray;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return array;
                }
            }
            
            public void RemoveAt(int index)
            {
                try
                {
                    if (index < 0 || index.GetType() != typeof(int))
                    {
                        throw new Exception("Indexin deyeri 0-dan kicik olmamali ve integer olmalidir");
                    }
                    if (index >= count)
                    {
                        throw new Exception("Daxil etdiyiniz index movcud deyil");
                    }
                    int[] newArray = new int[count - 1];
                    for (int i = 0, j = 0; i < this.array.Length; i++, j++)
                    {
                        if (i == index)
                        {
                            j--;
                            continue;
                        }
                        newArray[j] = this.array[i];
                    }
                    this.array = newArray;
                    count--;
                    capasity--;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            public void AddRange(int[] array)
            {
                int generalLength = count + array.Length;
                if (capasity <= generalLength)
                {
                    int[] newArray = new int[generalLength * 2];
                    for (int i = 0; i < count; i++)
                    {
                        newArray[i] = this.array[i];
                    }
                    this.array = newArray;
                    capasity *= 2;
                }
                for (int i = count, j = 0; i < generalLength; i++, j++)
                {
                    this.array[i] = array[j];
                    count++;
                }
            }
            public void Reverse()
            {
                int[] newArray = new int[count];
                for (int i = count - 1, j = 0; i >= 0; i--, j++)
                {
                    newArray[j] = this.array[i];
                }
                this.array = newArray;
            }
           
            public void RemoveRange(int firstIndex, int lastIndex)
            {
                try
                {
                    if (firstIndex >= lastIndex || firstIndex < 0 || lastIndex < 0 || firstIndex >= count || lastIndex > count)
                    {
                        throw new Exception("Index duzgun verilmemisdir");
                    }
                    int indexDifference = lastIndex - firstIndex + 1;
                    int[] newArray = new int[count - indexDifference];
                    for (int i = 0, j = 0; j < newArray.Length; j++, i++)
                    {
                        if (firstIndex <= i && i <= lastIndex)
                        {
                            j--;
                            continue;
                        }
                        newArray[j] = this.array[i];
                    }
                    this.array = newArray;
                    count = count - indexDifference;
                    capasity = capasity - indexDifference;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public void Add(int x)
            {
                try
                {
                    if (x.GetType() != typeof(int))
                    {
                        throw new Exception("Reqem daxil edin");
                    }
                    if (capasity <= count)
                    {
                        int[] newArray = new int[count * 2];
                        for (int i = 0; i < array.Length; i++)
                        {
                            newArray[i] = array[i];
                        }
                        array = newArray;
                        capasity *= 2;
                    }
                    this.array[count] = x;
                    count++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
