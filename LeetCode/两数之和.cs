public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] result = new int[2];
        int a,b;
        for(int i = 0; i < nums.Length; i++ )
        {
            a = nums[i];
            b = target - a;
            for (int j = i+1; j < nums.Length; j++)
            {
                if( b == nums[j] )
                {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }
        return result;
    }
}