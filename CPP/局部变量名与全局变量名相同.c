#include "stdio.h"

int i=99;

//局部变量作用域
int Test()
{
    int i = 100;
    printf("i=%d\n", i);    //这里的i是局部变量
    return 0;
}

//全局变量作用域
int Test2()
{
    Test();                 //Test中的i不会影响到外面的变量，因为函数执行完，函数体内的变量已经被抛弃了
    printf("i=%d\n", i);    //这里的i是全局变量
    return 0;
}

//全局变量作用域
int Test3()
{
    printf("i=%d\n", i);    //这里的i是全局变量
    return 0;
}

int main()
{
    int res=0;

    res=Test2();
    res=Test3();

    if (res == 0)
        return 0;
    else
        return 1;
}