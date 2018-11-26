using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    public class Lake
    {
        List<int> even = new List<int>();
        List<int> odd = new List<int>();

        public Lake(int[] arr)
        {
            FillLists(arr);
        }

        private void FillLists(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even.Add(arr[i]);
                }
                else
                {
                    odd.Add(arr[i]);
                }
            }
            odd.Reverse();

            foreach (var item in odd)
            {
                even.Add(item);
            }
        }

        public override string ToString()
        {
            return string.Join(", ", even);
        }
    }
}
