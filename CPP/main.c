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

//ȫ�ֱ���������
int Test2()
{
    printf("i=%d\n", i);
    return 0;
}

//����ϵͳ����
int CommonSystemFun()
{
    int i;
    double x;

    printf("������һ����Ȼ����\n");

    scanf("%d", &i);
    printf("%d ��ƽ�����ǣ�%lf \n", i, sqrt(i));
    printf("%d �ľ���ֵ�ǣ�%d \n", i, abs(i));

    printf("������һ��������\n");
    scanf("%lf", &x);
    printf("%lf ��ƽ�����ǣ�%lf \n", x, sqrt(x));
    printf("%lf �ľ���ֵ�ǣ�%lf \n", x, fabs(x));

    return 0;
}

// ��x,y,z
// ��30���ˣ����������ˡ�Ů�˺�С������һ�ҷ��ݳԷ�������50���
// ÿ�����˻�3���ÿ��Ů�˻�2���ÿ��С����1���
// �����ˡ�Ů�˺�С���������ֱ�Ϊ���٣�
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
                printf("�����ֱ�Ϊ�����ˣ�%2d��Ů�ˣ�%2d�����ӣ�%2d\n", men, wonmen, children);
            }
        }
    }

    printf("\n");

    return 0;
}

//�žų˷���
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

//����������������������ָ�ڴ���1����Ȼ���У�����1�����������ⲻ���ٱ�������Ȼ����������������к�����
int IsPrime()
{

    int num, i;
    bool isPrime = true;

    printf("������һ������1����������");
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
        printf("%d ��������\n", num);
    }
    else
    {
        printf("%d ����������\n", num);
    }

    // printf("%d", (12 % 5));
    return 0;
}
//����������������������ָ�ڴ���1����Ȼ���У�����1�����������ⲻ���ٱ�������Ȼ����������������к�����
int IsPrime2()
{

    int num, i;

    printf("������һ������1����������");
    scanf("%d", &num);

    for (i = 2; i < num; i++)
    {
        if (0 == num % i)
            break;
    }
    if (i == num)
    {
        printf("%d ��������\n", num);
    }
    else
    {
        printf("%d ����������\n", num);
    }

    return 0;
}
//�����ж�
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
//��1���������֮�����е�����������������
int LotOfPrime()
{
    int num;

    printf("������һ������1����������");

    scanf("%d", &num);

    for (int i = 2; i <= num; i++)
    {
        if (IsPrimeCore(i))
            printf("������%d \n", i);
    }

    return 0;
}

//�����ʽ��
int PrintFormat()
{
    int num = 10002;
    printf("a=%d, ", num);
    printf("b=%6d, ", num);
    printf("c=%06d, ", num);
    printf("d=%.2d", num);
    return 0;
}

//�����������������λ��
int ComDigit()
{
    int input, output;
    output = 0;
    printf("������ a number \n");
    scanf("%d", &input);
    printf("�����������Ϊ��%d\n", input);

    while (input > 0)
    {
        output++;
        input /= 10;
        printf("����ֵ��%2d=%d\n", output, input);
    }
    printf("input=%.2d, output=%02d", output, output);
    return 0;
}

// ���ܱ�3�����Ҹ�λ��Ϊ6����λ���ж��ٸ�
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

    printf("�ܱ�3�����Ҹ�λ��Ϊ6����λ����%d��\n", count);
    return 0;
}

//�������
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

    // system("pause"); //�밴���������
    // getch();         //��ͣ���˳�

    if (res == 0)
        return 0;
    else
        return 1;
}