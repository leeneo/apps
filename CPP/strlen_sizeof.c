#include "stdio.h"
#include <string.h>

void main()
{

    char sArr[] = "ILOVEC";
    char sArr2[] = {'I', 'L', 'O', 'V', 'E', 'C', '\0'};

    // 用strlen()求字符串长度
    printf("length of %s=%d\n", sArr, strlen(sArr));
    printf("length of %s=%d\n", sArr2, strlen(sArr2));

    int nums[6] = {12, 4, 6, 8, 1, 18};
    int length = 0;

    // sizeof 获得的是该数组所占的内存大小（字节长度）
    printf("sizeof of nums[]=%d\n", sizeof(nums)); //输出length of nums=24

    for (int i = 0; i < 6; i++)
    {
        //通过数组所占内存总空间除以单个元素占的内存空间大小，来获得数组字面量长度
        length = sizeof(nums) / sizeof(nums[4]);                                
        printf("单个 nums[%d]=%2d 元素所占内存长度 = %d\n", i,nums[i], sizeof(nums[i])); //输出length of data=20
    }
    printf("length of nums[6]=%d\n", length); //输出length of data=20

}