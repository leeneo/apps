/** 
 * ���ߣ�Leeneo
 * ���䣺leeneo@xingzhihen.com
*/

#include "stdio.h"
#include "stdlib.h"
#include "conio.h"

//����Ԫ������������������
void comDigit2(double glPrice, double glPrice2, double glPrice3)
{
    /**
    * glPrice   //ʹ�ü��۸�¶
    * glPrice2  //ʹ���̳ǵľ�����Դ������ 10Ԫ��/�飨һ��20���൱��400����Դ��¶��  
    * glPrice3  //ʹ���̳ǵİ���ۿ���Դ������  17Ԫ��/��
    */
    double treePrice;

    treePrice = 1; //��ϵԪ���������������1��һ��

    //ι���ɹ�����Ԫ�����������ܹ�520��
    double nlfPrice = (treePrice + glPrice) / 520 * 100;
    double nlfPrice2 = (treePrice + glPrice2) / 520 * 100;
    double nlfPrice3 = (treePrice + glPrice3) / 520 * 100;

    printf("\n��ǰ������һ���������ĳɱ��ۣ����۸�¶ι����Ϊ %.2lf ��\n", nlfPrice);
    printf("\n��ǰ������һ���������ĳɱ��ۣ����ø���ι����Ϊ %.2lf ��\n", nlfPrice2);
    // printf("\n��ǰ������һ���������ĳɱ��ۣ��̳ǰ���ۿ۸���ι����Ϊ %.2lf ��\n", nlfPrice3);
}

//������ܵ�����
void comDigit()
{
    double ybPrice, glPrice, nlfPrice, goldPrice;

    // double tree = 130, gamePrice = 3.66; //tree:ҡǮ�����ʣ�gamePrice������Ԫ����
    // double treePrice = 130 / 3.66;       //ҡǮ���ɱ�

    printf("�����뵱ǰ������ Ԫ��/��۱���������1 Ԫ�� = 1.42 ������ 1.42���� \n");
    scanf("%lf", &ybPrice);

    double treePrice = (double)130 * (ybPrice * 328 / 1200);  //ʹ�þ��þ��ʣ�1200����/328Ԫ��
    double treePrice2 = (double)130 * (ybPrice * 234 / 1200); //ʹ�ð���ۿ�ȯ���ʣ�1200����/234Ԫ��
    double treePrice3 = ybPrice * 23;                         //ʹ�þ��ûû����ٱ�ϻ��23Ԫ��1������3����Դ�����أ��൱��60����Դ��¶��
    double treePrice4 = ybPrice * 39;                         //ʹ�ð���ۿ�ȯ�û����ٱ�ϻ��39Ԫ��1������3����Դ�����أ��൱��60����Դ��¶��

    printf("\n�����뵱ǰ������ ��¶���۱���������1 ��¶ = 4 �� 30 ͭ������ 0.043���� \n");
    scanf("%lf", &glPrice);
    printf("\n�����뵱ǰ������ ���𵥼۱���������1 ���� = 9 �� 36 ͭ������ 0.096���� \n");
    scanf("%lf", &goldPrice);

    treePrice = treePrice + goldPrice * 2;   //ֻ��ʹ�þ��ʣ����þ��ʻ��߰���ۿ۾��ʣ�����������Ҫ���Ͼ���ļ۸�
    treePrice2 = treePrice2 + goldPrice * 2; //ֻ��ʹ�þ��ʣ����þ��ʻ��߰���ۿ۾��ʣ�����������Ҫ���Ͼ���ļ۸�
    // ι��һ��ҡǮ������Ԫ�������������Ҫ��¶520��
    double glPriceSale = glPrice * 460;                            //ʹ�ü��۸�¶���ӻû����ٱ�ϻ����3������=60����¶����
    glPrice = glPrice * 520;                                       //ʹ�ü��۸�¶
    double glPrice2 = (double)520 / 400 * 10 * ybPrice;            //ʹ���̳ǵľ�����Դ������ 10Ԫ��/�飨һ��20���൱��400����Դ��¶��
    double glPrice3 = (double)520 / 400 * 17 * ybPrice;            //ʹ���̳ǵİ���ۿ���Դ������  17Ԫ��/��
    double glPriceSale2 = (double)(520 - 60) / 400 * 10 * ybPrice; //�û����ٱ�ϻ��ʹ���̳ǵľ�����Դ������ 10Ԫ��/�飨һ��20���൱��400����Դ��¶��
    double glPriceSale3 = (double)(520 - 60) / 400 * 17 * ybPrice; //�û����ٱ�ϻ��ʹ���̳ǵİ���ۿ���Դ������  17Ԫ��/��

    // ������
    // printf("\n���ø���+�㿨����Ϊ %.2lf + %.2lf ��\n", glPrice2, ybPrice);
    // printf("\n���þ�����+���۸�¶Ϊ %.2lf + %.2lf ��\n", treePrice, glPrice);
    // printf("\n���þ�����+���ø��� %.2lf + %.2lf ��\n", treePrice, glPrice2);
    // printf("\n����ۿ۾�����+���ø��� %.2lf + %.2lf ��\n", treePrice2, glPrice2);

    //���۸�¶�۸� ι���ɹ����ɾ��ܵ��ܹ�552��
    double jndPrice = (treePrice + glPrice) / 552 * 100;       //���þ�����+���۸�¶
    double jndPrice2 = (treePrice2 + glPrice) / 552 * 100;     //����ۿ۾�����+���۸�¶
    double jndPrice3 = (treePrice3 + glPriceSale) / 552 * 100; //���ûû����ٱ�ϻ+���۸�¶
    double jndPrice4 = (treePrice4 + glPriceSale) / 552 * 100; //����ۿ�ȯ�û����ٱ�ϻ+���۸�¶

    double jndPrice5 = (treePrice + glPrice2) / 552 * 100;       //���þ�����+���ø���
    double jndPrice7 = (treePrice2 + glPrice2) / 552 * 100;      //����ۿ۾�����+���ø���
    double jndPrice9 = (treePrice3 + glPriceSale2) / 552 * 100;  //���ûû����ٱ�ϻ+���ø���
    double jndPrice11 = (treePrice4 + glPriceSale2) / 552 * 100; //����ۿۻû����ٱ�ϻ+���ø���

    // һ������°���ۿ��ز�����ڼ��۸�¶���Ұ���ۿ�ȯͨ�������������¶��������ʱ�Ŷ������������
    double jndPrice6 = (treePrice + glPrice3) / 552 * 100;       //���þ�����+����ۿ۸���
    double jndPrice8 = (treePrice2 + glPrice3) / 552 * 100;      //����ۿ۾�����+����ۿ۸���
    double jndPrice10 = (treePrice3 + glPriceSale3) / 552 * 100; //���ûû����ٱ�ϻ+����ۿ۸���
    double jndPrice12 = (treePrice4 + glPriceSale3) / 552 * 100; //����ۿۻû����ٱ�ϻ+����ۿ۸���

    printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ����ûû����ٱ�ϻ+���۸�¶��Ϊ %.2lf ��\n", jndPrice3);
    printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ����ûû����ٱ�ϻ+���ø��أ�Ϊ %.2lf ��\n", jndPrice9);
    printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ�����ۿ۾�����+���۸�¶��Ϊ %.2lf ��\n", jndPrice2);
    printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ�����ۿ۾�����+���ø��أ�Ϊ %.2lf ��\n", jndPrice7);
    printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ����þ�����+���۸�¶��Ϊ %.2lf ��\n", jndPrice);
    printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ����þ�����+���ø��أ�Ϊ %.2lf ��\n", jndPrice5);

    //  ���ھ��ø��ؼ����ðٱ�ϻ�ļ۸�Զ���ڰ���ۿ۹���ļ۸�����ͨ������²����������ۿ�ȯ����û����
    // printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ�����ۿ�ȯ�û����ٱ�ϻ+���۸�¶��Ϊ %.2lf ��\n", jndPrice4);
    // printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ�����ۿۻû����ٱ�ϻ+���ø��أ�Ϊ %.2lf ��\n", jndPrice11);
    // printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ����þ�����+����ۿ۸��أ�Ϊ %.2lf ��\n", jndPrice6);
    // printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ�����ۿ۾�����+����ۿ۸��أ�Ϊ %.2lf ��\n", jndPrice8);
    // printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ����ûû����ٱ�ϻ+����ۿ۸��أ�Ϊ %.2lf ��\n", jndPrice10);
    // printf("\n��ǰ������һ�����ܵ��ĳɱ��ۣ�����ۿۻû����ٱ�ϻ+����ۿ۸��أ�Ϊ %.2lf ��\n", jndPrice12);

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

    printf("\n\n\n\n       *******************���ߣ�Leeneo*******************\n");
    printf("*******************���䣺leeneo@xingzhihen.com*******************\n");

    return 0;
}
