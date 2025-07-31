// Problem: Longest Substring Without Repetition
// Tags: Hash Table, Two Pointers
// Difficulty: Medium
// Time: O(n)
// Space: O(min(m, n))

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        
        Dictionary<char, int> positionChar = new();
        int leftIndex = 0;
        int maxLength = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (positionChar.ContainsKey(s[i]) && positionChar[s[i]] >= leftIndex)
            {
                leftIndex = positionChar[s[i]] + 1;
            }

            positionChar[s[i]] = i;
            maxLength = Math.Max(maxLength, i - leftIndex + 1);
        }

        return maxLength;
    }
}