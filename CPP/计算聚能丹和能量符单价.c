/** 
 * ���ߣ�Leeneo
 * ���䣺leeneo@xingzhihen.com
*/

#include "stdio.h"
#include "stdlib.h"
#include "conio.h"

//����Ԫ������������������
void comDigit2(float glPrice)
{
    float treePrice, nlfPrice;

    treePrice = 1; //��ϵԪ���������������1��һ��

    nlfPrice = (treePrice + glPrice) / 520 * 100; //ι���ɹ�����Ԫ�����������ܹ�520��

    printf("\n��ǰ������ һ���������� �ɱ��� Ϊ %.3f ��\n", nlfPrice);
}

//������ܵ�����
void comDigit()
{
    float ybPrice, glPrice, yndPrice, nlfPrice;

    float tree = 130, gamePrice = 3.65; //tree:ҡǮ�����ʣ�gamePrice������Ԫ����
    float treePrice = 130 / 3.65;       //ҡǮ���ɱ�

    printf("�����뵱ǰ������ Ԫ��/��۱���������1 Ԫ�� = 1.42 ������ 1.42���� \n");
    scanf("%f", &ybPrice);
    treePrice = treePrice * ybPrice;

    printf("\n�����뵱ǰ������ ��¶���۱���������1 ��¶ = 4 �� 30 ͭ������ 0.043���� \n");
    scanf("%f", &glPrice);
    glPrice = glPrice * 520; //ι��һ��ҡǮ������Ԫ�������������Ҫ��¶520��

    yndPrice = (treePrice + glPrice) / 552 * 100; //ι���ɹ����ɾ��ܵ��ܹ�552��

    printf("\n��ǰ������ һ�����ܵ��� �ɱ��� Ϊ %.3f ��\n", yndPrice);

    comDigit2(glPrice);
}

int main()
{
    comDigit();

    printf("\n\n\n\n       *******************���ߣ�Leeneo*******************\n");
    printf("*******************���䣺leeneo@xingzhihen.com*******************\n");

    system("pause");
    // getch();

    return 0;
}
