/** 
 * 作者：Leeneo
 * 邮箱：leeneo@xingzhihen.com
*/

#include "stdio.h"
#include "stdlib.h"
#include "conio.h"

//计算元魂珠杂物能量符单价
void comDigit2(float glPrice)
{
    float treePrice, nlfPrice;

    treePrice = 1; //各系元魂珠灵符宝贝单价1金一个

    nlfPrice = (treePrice + glPrice) / 520 * 100; //喂养成功生成元魂珠能量符总共520个

    printf("\n当前服务器 一个能量符的 成本价 为 %.3f 银\n", nlfPrice);
}

//计算聚能丹单价
void comDigit()
{
    float ybPrice, glPrice, yndPrice, nlfPrice;

    float tree = 130, gamePrice = 3.65; //tree:摇钱树军资，gamePrice：军资元宝比
    float treePrice = 130 / 3.65;       //摇钱树成本

    printf("请输入当前服务器 元宝/金价比例（例：1 元宝 = 1.42 金：输入 1.42）： \n");
    scanf("%f", &ybPrice);
    treePrice = treePrice * ybPrice;

    printf("\n请输入当前服务器 甘露单价比例（例：1 甘露 = 4 银 30 铜：输入 0.043）： \n");
    scanf("%f", &glPrice);
    glPrice = glPrice * 520; //喂养一棵摇钱树或者元魂珠灵符宝贝需要甘露520个

    yndPrice = (treePrice + glPrice) / 552 * 100; //喂养成功生成聚能丹总共552个

    printf("\n当前服务器 一个聚能丹的 成本价 为 %.3f 银\n", yndPrice);

    comDigit2(glPrice);
}

int main()
{
    comDigit();

    printf("\n\n\n\n       *******************作者：Leeneo*******************\n");
    printf("*******************邮箱：leeneo@xingzhihen.com*******************\n");

    system("pause");
    // getch();

    return 0;
}
