#include "stdio.h"
#include <string.h>

int find_max(int nums[], int len)
{
    int i, max_num = nums[0];
    for (i = 1; i < len; i++)
    {
        if (nums[i] > max_num)
        {
            max_num = nums[i];
        }
    }
    return max_num;
}

void main()
{
    int nums[5] = {2, 14, 6, 8, 1};
    int max = find_max(nums,5);
    printf("nums[] 里的最大值是 ：%d\n", max);
}