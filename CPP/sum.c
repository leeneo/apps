#include "stdio.h"

void main()
{
    float x;
    float sum=0;
    while(1){
        scanf("%f",&x);
        sum+=x;
        printf("sum:%.2f\n\n",sum);
    }
}