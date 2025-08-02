// Problem: Median of Two Sorted Arrays
// Tags: Binary Search, Array, Divide and Conquer
// Difficulty: Hard
// Time: O(log(min(m, n)))
// Space: O(1)

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
        /* 
         * Idea: instead of merging both arrays, do a binary search with them still
         * split. So we start with left half from nums1, right half from nums2, compare
         * values and adjust the limits of the binary search if needed.
        */

        // Ensures nums1 is the smaller array
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }
        
        // Binary search on nums1
        int left = 0;
        int right = nums1.Length;
        int x = nums1.Length;
        int y = nums2.Length;

        while (left <= right)
        {
            int partitionX = (left + right) / 2; // Where nums1 will split
            int partitionY = (x + y + 1) / 2 - partitionX; // Where nums2 will split

            // for nums1 
            // biggest element on the left side of the partition
            int maxLeftX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
            // smallest element on right side partition
            int minRightX = (partitionX == x) ? int.MaxValue : nums1[partitionX]; 

            // same above, for nums2
            int maxLeftY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
            int minRightY = (partitionY == y) ? int.MaxValue : nums2[partitionY];    
            
            // validate the split
            if (maxLeftX <= minRightY && maxLeftY <= minRightX)
            {
                // found the correct partition
                if ((x + y) % 2 == 0)
                {
                    return ((double)Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                }
                else
                {
                    return (double)Math.Max(maxLeftX, maxLeftY);
                }
            }
            else if (maxLeftX > minRightY)
            {
                // too far right in nums1 > move left
                right = partitionX - 1;
            }
            else
            {
                // Too far left in nums1 > move right
                left = partitionX + 1;
            }
        }

        return 0.0;
    }
}