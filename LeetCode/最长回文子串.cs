/*
给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。
示例 1：
输入: "babad"
输出: "bab"
注意: "aba" 也是一个有效答案。
示例 2：
输入: "cbbd"
输出: "bb"
 */


public class Solution
{
    public string LongestPalindrome(string s)
    {
        if (s.Length == 0)
        {
            return "";
        }
        string[] str = { s, s.Substring(0, s.Length - 1), s.Substring(1, s.Length - 1) };
        string temp;
        string result = "";
        for (int o = 0; o < 3; o++)
        {
            s = str[o];
            if (s.Length % 2 == 0)
            {
                for (int i = 0; i < s.Length - 1; i++)
                {
                    int j = i;
                    int k = i + 1;
                    char a = s[j];
                    char b = s[k];
                    bool x = false;
                    while (a == b && j > 0 && k < s.Length - 1)
                    {
                        a = s[--j];
                        b = s[++k];
                        x = true;
                    }
                    if (a == b)
                    {
                        temp = s.Substring(j, k - j + 1);
                    }
                    else if (x)
                    {
                        temp = s.Substring(++j, k - j);
                    }
                    else
                    {
                        temp = s.Substring(j, k - j);
                    }
                    result = result.Length < temp.Length ? temp : result;
                }
            }
            else
            {
                if (s.Length == 1)
                {
                    result = result.Length < s.Length ? s : result; ;
                }
                for (int i = 1; i < s.Length - 1; i++)
                {
                    int j = i - 1;
                    int k = i + 1;
                    char a = s[j];
                    char b = s[k];
                    bool x = false;
                    while (a == b && j > 0 && k < s.Length - 1)
                    {
                        a = s[--j];
                        b = s[++k];
                        x = true;
                    }
                    if (a == b)
                    {
                        temp = s.Substring(j, k - j + 1);
                    }
                    else if (x)
                    {
                        temp = s.Substring(++j, k - j);
                    }
                    else
                    {
                        temp = s.Substring(j, k - j - 1);
                    }
                    result = result.Length < temp.Length ? temp : result;
                }
            }
        }

        return result;
    }
}