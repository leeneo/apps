#include "stdio.h"

int main()
{
    int i = 0;
    printf("������ a number \n");
    // scanf("%d", &i);
    scanf("%2d", &i);        //ֻ��ȡǰ��λ
    printf("%%d==>%d\n", i);
    printf("%%2d==>%2d\n", i);
    printf("%%02d==>%02d\n", i);
    printf("%%.2d==>%.2d\n", i);
    printf("%%s==>%s\n", "i");
    puts("%d %s %%\n"); //�޸�ʽ���

    return 0;
}
