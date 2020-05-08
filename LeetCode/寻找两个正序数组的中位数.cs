public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        double result = 0;
        List<int> list = new List<int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            list.Add(nums1[i]);
        }
        for (int i = 0; i < nums2.Length; i++)
        {
            list.Add(nums2[i]);
        }
        list.Sort();

        if (list.Count % 2 == 0)
        {
            result = (int)(list[list.Count / 2 - 1]) + (int)(list[list.Count / 2]);
            result *= 0.5;
        }
        else
        {
            result = (int)(list[(list.Count + 1) / 2 - 1]);
        }
        return result;
    }
}