#include "stdio.h"
#include <string.h>

void main()
{

    char sArr[] = "ILOVEC";
    char sArr2[] = {'I', 'L', 'O', 'V', 'E', 'C', '\0'};

    // ��strlen()���ַ�������
    printf("length of %s=%d\n", sArr, strlen(sArr));
    printf("length of %s=%d\n", sArr2, strlen(sArr2));

    int nums[6] = {12, 4, 6, 8, 1, 18};
    int length = 0;

    // sizeof ��õ��Ǹ�������ռ���ڴ��С���ֽڳ��ȣ�
    printf("sizeof of nums[]=%d\n", sizeof(nums)); //���length of nums=24

    for (int i = 0; i < 6; i++)
    {
        //ͨ��������ռ�ڴ��ܿռ���Ե���Ԫ��ռ���ڴ�ռ��С���������������������
        length = sizeof(nums) / sizeof(nums[4]);                                
        printf("���� nums[%d]=%2d Ԫ����ռ�ڴ泤�� = %d\n", i,nums[i], sizeof(nums[i])); //���length of data=20
    }
    printf("length of nums[6]=%d\n", length); //���length of data=20

}