/** 
 * ���ߣ�Leeneo
 * ���䣺leeneo@xingzhihen.com
*/

#include "stdio.h"
#include "stdlib.h"
#include "conio.h"

//������ܵ�����
void comDigit()
{
    float ybPrice, glPrice, yndPrice;

    float tree = 130, gamePrice = 3.65; //tree:ҡǮ�����ʣ�gamePrice������Ԫ����

    float treePrice = 130 / 3.65; //ҡǮ���ɱ�

    printf("�����뵱ǰ������ Ԫ��/��۱���������1 Ԫ�� = 1.42 ������ 1.42���� \n");
    scanf("%f", &ybPrice);
    treePrice = treePrice * ybPrice;

    printf("\n�����뵱ǰ������ ��¶���۱���������1 ��¶ = 4 �� 30 ͭ������ 0.043���� \n");
    scanf("%f", &glPrice);
    glPrice = glPrice * 520; //ι��һ������Ҫ��¶520��

    yndPrice = (treePrice + glPrice) / 552 * 100; //ι���ɹ����ɾ��ܵ��ܹ�552��

    printf("\n��ǰ������ һ�����ܵ��� �ɱ��� Ϊ %.3f ��\n", yndPrice);
    printf("\n\n\n\n       *******************���ߣ�Leeneo*******************\n", yndPrice);
    printf("*******************���䣺leeneo@xingzhihen.com*******************\n", yndPrice);
}

int main()
{
    comDigit();

    system("pause");
    // getch();

    return 0;
}
