#include "stdio.h"
#include "stdlib.h"
#include "math.h"
#include "stdbool.h"
#include "conio.h"

int i=99;
//
int Test()
{
    int i = 9;
    printf("i=%d\n", i);
    return 0;
}

//全局变量作用域
int Test2()
{
    printf("i=%d\n", i);
    return 0;
}

//常用系统函数
int CommonSystemFun()
{
    int i;
    double x;

    printf("请输入一个自然数：\n");

    scanf("%d", &i);
    printf("%d 的平方根是：%lf \n", i, sqrt(i));
    printf("%d 的绝对值是：%d \n", i, abs(i));

    printf("请输入一个分数：\n");
    scanf("%lf", &x);
    printf("%lf 的平方根是：%lf \n", x, sqrt(x));
    printf("%lf 的绝对值是：%lf \n", x, fabs(x));

    return 0;
}

// 求x,y,z
// 有30个人，其中有男人、女人和小孩，在一家饭馆吃饭共花了50先令；
// 每个男人花3先令，每个女人花2先令，每个小孩花1先令；
// 问男人、女人和小孩的人数分别为多少？
int Equation()
{
    int allPeople, allMoney, men, wonmen, children;
    allPeople = 30;
    allMoney = 50;

    for (men = 1; men <= allMoney / 3; men++)
    {
        for (wonmen = 1; wonmen <= allMoney / 2; wonmen++)
        {
            children = allPeople - men - wonmen;
            if (men * 3 + wonmen * 2 + children * 1 == 50)
            {
                printf("人数分别为，男人：%2d，女人：%2d，孩子：%2d\n", men, wonmen, children);
            }
        }
    }

    printf("\n");

    return 0;
}

//九九乘法表
int Multiplication()
{
    int i, j;
    for (i = 1; i < 10; i++)
    {
        for (j = 1; j <= i; j++)
        {
            printf("%d*%d=%2d  ", j, i, j * i);
            if (i == j)
                printf("\n");
        }
    }

    printf("\n");

    return 0;
}

//求素数（质数）：质数是指在大于1的自然数中，除了1和它本身以外不能再被其他自然数整除的数，否则叫合数。
int IsPrime()
{

    int num, i;
    bool isPrime = true;

    printf("请输入一个大于1的正整数：");
    scanf("%d", &num);

    for (i = 2; i < num; i++)
    {
        if (num % i == 0)
        {
            isPrime = false;
            break;
        }
    }
    if (isPrime)
    {
        printf("%d 是素数！\n", num);
    }
    else
    {
        printf("%d 不是素数！\n", num);
    }

    // printf("%d", (12 % 5));
    return 0;
}
//求素数（质数）：质数是指在大于1的自然数中，除了1和它本身以外不能再被其他自然数整除的数，否则叫合数。
int IsPrime2()
{

    int num, i;

    printf("请输入一个大于1的正整数：");
    scanf("%d", &num);

    for (i = 2; i < num; i++)
    {
        if (0 == num % i)
            break;
    }
    if (i == num)
    {
        printf("%d 是素数！\n", num);
    }
    else
    {
        printf("%d 不是素数！\n", num);
    }

    return 0;
}
//素数判断
bool IsPrimeCore(int num)
{

    int i;

    for (i = 2; i < num; i++)
    {
        if (0 == num % i)
            break;
    }
    if (i == num)
    {
        return true;
    }
    else
    {
        return false;
    }
}
//求1到输入的数之间所有的素数，包括输入数
int LotOfPrime()
{
    int num;

    printf("请输入一个大于1的正整数：");

    scanf("%d", &num);

    for (int i = 2; i <= num; i++)
    {
        if (IsPrimeCore(i))
            printf("素数：%d \n", i);
    }

    return 0;
}

//输出格式符
int PrintFormat()
{
    int num = 10002;
    printf("a=%d, ", num);
    printf("b=%6d, ", num);
    printf("c=%06d, ", num);
    printf("d=%.2d", num);
    return 0;
}

//计算输入的正整数的位数
int ComDigit()
{
    int input, output;
    output = 0;
    printf("请输入 a number \n");
    scanf("%d", &input);
    printf("输入的正整数为：%d\n", input);

    while (input > 0)
    {
        output++;
        input /= 10;
        printf("计算值：%2d=%d\n", output, input);
    }
    printf("input=%.2d, output=%02d", output, output);
    return 0;
}

// 求能被3整除且个位数为6的五位数有多少个
int FiveDigit()
{
    int number = 1000, count = 0;
    while (number <= 9999)
    {
        if ((number * 10 + 6) % 3 == 0)
        {
            count++;
        }
        number++;
    }

    printf("能被3整除且个位数为6的五位数有%d个\n", count);
    return 0;
}

//函数入口
int main()
{
    int res = 0;
    // res = ComDigit();
    // res = FiveDigit();
    // res = PrintFormat();
    // res = IsPrime();
    // res = Multiplication();
    // res = Equation();
    // res = LotOfPrime();
    // res = CommonSystemFun();

    res = Test();
    res = Test2();

    // system("pause"); //请按任意键继续
    // getch();         //暂停不退出

    if (res == 0)
        return 0;
    else
        return 1;
}