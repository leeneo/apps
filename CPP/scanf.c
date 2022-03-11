#include "stdio.h"

int main()
{
    int i = 0;
    printf("请输入 a number \n");
    // scanf("%d", &i);
    scanf("%2d", &i);        //只截取前两位
    printf("%%d==>%d\n", i);
    printf("%%2d==>%2d\n", i);
    printf("%%02d==>%02d\n", i);
    printf("%%.2d==>%.2d\n", i);
    printf("%%s==>%s\n", "i");
    puts("%d %s %%\n"); //无格式输出

    return 0;
}
