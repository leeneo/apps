/** 
 * 作者：Leeneo
 * 邮箱：leeneo@xingzhihen.com
*/

#include "stdio.h"
#include "stdlib.h"
#include "conio.h"

//计算元魂珠杂物能量符单价
void comDigit2(double glPrice, double glPrice2, double glPrice3)
{
    /**
    * glPrice   //使用寄售甘露
    * glPrice2  //使用商城的军饷桃源·甘霖 10元宝/组（一组20个相当于400个桃源甘露）  
    * glPrice3  //使用商城的半价折扣桃源·甘霖  17元宝/组
    */
    double treePrice;

    treePrice = 1; //各系元魂珠灵符宝贝单价1金一个

    //喂养成功生成元魂珠能量符总共520个
    double nlfPrice = (treePrice + glPrice) / 520 * 100;
    double nlfPrice2 = (treePrice + glPrice2) / 520 * 100;
    double nlfPrice3 = (treePrice + glPrice3) / 520 * 100;

    printf("\n当前服务器一个能量符的成本价（寄售甘露喂养）为 %.2lf 银\n", nlfPrice);
    printf("\n当前服务器一个能量符的成本价（军饷甘霖喂养）为 %.2lf 银\n", nlfPrice2);
    // printf("\n当前服务器一个能量符的成本价（商城半价折扣甘霖喂养）为 %.2lf 银\n", nlfPrice3);
}

//计算聚能丹单价
void comDigit()
{
    double ybPrice, glPrice, nlfPrice, goldPrice;

    // double tree = 130, gamePrice = 3.66; //tree:摇钱树军资，gamePrice：军资元宝比
    // double treePrice = 130 / 3.66;       //摇钱树成本

    printf("请输入当前服务器 元宝/金价比例（例：1 元宝 = 1.42 金：输入 1.42）： \n");
    scanf("%lf", &ybPrice);

    double treePrice = (double)130 * (ybPrice * 328 / 1200);  //使用军饷军资：1200军资/328元宝
    double treePrice2 = (double)130 * (ybPrice * 234 / 1200); //使用半价折扣券军资：1200军资/234元宝
    double treePrice3 = ybPrice * 23;                         //使用军饷幻化·百宝匣：23元宝1个，送3个桃源·甘霖（相当于60个桃源甘露）
    double treePrice4 = ybPrice * 39;                         //使用半价折扣券幻化·百宝匣：39元宝1个，送3个桃源·甘霖（相当于60个桃源甘露）

    printf("\n请输入当前服务器 甘露单价比例（例：1 甘露 = 4 银 30 铜：输入 0.043）： \n");
    scanf("%lf", &glPrice);
    printf("\n请输入当前服务器 精金单价比例（例：1 精金 = 9 银 36 铜：输入 0.096）： \n");
    scanf("%lf", &goldPrice);

    treePrice = treePrice + goldPrice * 2;   //只有使用军资（军饷军资或者半价折扣军资）换的树才需要加上精金的价格
    treePrice2 = treePrice2 + goldPrice * 2; //只有使用军资（军饷军资或者半价折扣军资）换的树才需要加上精金的价格
    // 喂养一棵摇钱树或者元魂珠灵符宝贝需要甘露520个
    double glPriceSale = glPrice * 460;                            //使用寄售甘露，加幻化·百宝匣（送3个甘霖=60个甘露），
    glPrice = glPrice * 520;                                       //使用寄售甘露
    double glPrice2 = (double)520 / 400 * 10 * ybPrice;            //使用商城的军饷桃源·甘霖 10元宝/组（一组20个相当于400个桃源甘露）
    double glPrice3 = (double)520 / 400 * 17 * ybPrice;            //使用商城的半价折扣桃源·甘霖  17元宝/组
    double glPriceSale2 = (double)(520 - 60) / 400 * 10 * ybPrice; //幻化·百宝匣，使用商城的军饷桃源·甘霖 10元宝/组（一组20个相当于400个桃源甘露）
    double glPriceSale3 = (double)(520 - 60) / 400 * 17 * ybPrice; //幻化·百宝匣，使用商城的半价折扣桃源·甘霖  17元宝/组

    // 调试区
    // printf("\n军饷甘霖+点卡比例为 %.2lf + %.2lf 银\n", glPrice2, ybPrice);
    // printf("\n军饷军资树+寄售甘露为 %.2lf + %.2lf 银\n", treePrice, glPrice);
    // printf("\n军饷军资树+军饷甘霖 %.2lf + %.2lf 银\n", treePrice, glPrice2);
    // printf("\n半价折扣军资树+军饷甘霖 %.2lf + %.2lf 银\n", treePrice2, glPrice2);

    //寄售甘露价格 喂养成功生成聚能丹总共552个
    double jndPrice = (treePrice + glPrice) / 552 * 100;       //军饷军资树+寄售甘露
    double jndPrice2 = (treePrice2 + glPrice) / 552 * 100;     //半价折扣军资树+寄售甘露
    double jndPrice3 = (treePrice3 + glPriceSale) / 552 * 100; //军饷幻化·百宝匣+寄售甘露
    double jndPrice4 = (treePrice4 + glPriceSale) / 552 * 100; //半价折扣券幻化·百宝匣+寄售甘露

    double jndPrice5 = (treePrice + glPrice2) / 552 * 100;       //军饷军资树+军饷甘霖
    double jndPrice7 = (treePrice2 + glPrice2) / 552 * 100;      //半价折扣军资树+军饷甘霖
    double jndPrice9 = (treePrice3 + glPriceSale2) / 552 * 100;  //军饷幻化·百宝匣+军饷甘霖
    double jndPrice11 = (treePrice4 + glPriceSale2) / 552 * 100; //半价折扣幻化·百宝匣+军饷甘霖

    // 一般情况下半价折扣霖不会低于寄售甘露，且半价折扣券通常不会用来买甘露，所以暂时排队以下四种情况
    double jndPrice6 = (treePrice + glPrice3) / 552 * 100;       //军饷军资树+半价折扣甘霖
    double jndPrice8 = (treePrice2 + glPrice3) / 552 * 100;      //半价折扣军资树+半价折扣甘霖
    double jndPrice10 = (treePrice3 + glPriceSale3) / 552 * 100; //军饷幻化·百宝匣+半价折扣甘霖
    double jndPrice12 = (treePrice4 + glPriceSale3) / 552 * 100; //半价折扣幻化·百宝匣+半价折扣甘霖

    printf("\n当前服务器一个聚能丹的成本价（军饷幻化·百宝匣+寄售甘露）为 %.2lf 银\n", jndPrice3);
    printf("\n当前服务器一个聚能丹的成本价（军饷幻化·百宝匣+军饷甘霖）为 %.2lf 银\n", jndPrice9);
    printf("\n当前服务器一个聚能丹的成本价（半价折扣军资树+寄售甘露）为 %.2lf 银\n", jndPrice2);
    printf("\n当前服务器一个聚能丹的成本价（半价折扣军资树+军饷甘霖）为 %.2lf 银\n", jndPrice7);
    printf("\n当前服务器一个聚能丹的成本价（军饷军资树+寄售甘露）为 %.2lf 银\n", jndPrice);
    printf("\n当前服务器一个聚能丹的成本价（军饷军资树+军饷甘霖）为 %.2lf 银\n", jndPrice5);

    //  由于军饷甘霖及军饷百宝匣的价格远低于半价折扣购买的价格，所以通常情况下不建议消耗折扣券购买幻化相关
    // printf("\n当前服务器一个聚能丹的成本价（半价折扣券幻化·百宝匣+寄售甘露）为 %.2lf 银\n", jndPrice4);
    // printf("\n当前服务器一个聚能丹的成本价（半价折扣幻化·百宝匣+军饷甘霖）为 %.2lf 银\n", jndPrice11);
    // printf("\n当前服务器一个聚能丹的成本价（军饷军资树+半价折扣甘霖）为 %.2lf 银\n", jndPrice6);
    // printf("\n当前服务器一个聚能丹的成本价（半价折扣军资树+半价折扣甘霖）为 %.2lf 银\n", jndPrice8);
    // printf("\n当前服务器一个聚能丹的成本价（军饷幻化·百宝匣+半价折扣甘霖）为 %.2lf 银\n", jndPrice10);
    // printf("\n当前服务器一个聚能丹的成本价（半价折扣幻化·百宝匣+半价折扣甘霖）为 %.2lf 银\n", jndPrice12);

    comDigit2(glPrice, glPrice2, glPrice3);
}

int main()
{
    comDigit();

    printf("\n");

    system("pause");

    printf("\n\n");

    // getch();

    // for (int i = 0; i < 100; i++)
    // {
    // }

    printf("\n\n\n\n       *******************作者：Leeneo*******************\n");
    printf("*******************邮箱：leeneo@xingzhihen.com*******************\n");

    return 0;
}
