using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculate
{
    public static class InterpolSearch
    {
        public static int[] execute(int[] a, int key)
        {
            int[] ans = new int[2];
            int mid = 0, left = 0, right = a.Length - 1;

            while (a[left] <= key && a[right] >= key)
            {
                mid = left + ((key - a[left]) * (right - left)) / (a[right] - a[left]);

                if (a[mid] < key) left = mid + 1;

                else if (a[mid] > key) right = mid - 1;

                else
                {
                    ans[0] = mid;
                    return ans;
                }
            }

            if (a[left] == key)
            {
                ans[0] = left;
                return ans;
            }

            else
            {
                ans[0] = mid;
                ans[1] = left;

                return ans;
            }
        }
    }
}
