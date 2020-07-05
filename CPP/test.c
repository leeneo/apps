#include "stdio.h"

int main()
{
    int i, j;
    j = 0;
    printf("ÇëÊäÈë a number \n");
    scanf("%2d", &i);
    printf("i=%d\n",i);

    while (i > 0)
    {
        j++;
        i /= 10;
        printf("i=%2d\n",i);
    }
    printf("i=%.2d, j=%02d",i,j);
    return 0;
}