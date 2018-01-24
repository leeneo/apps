// C编译器允许main没有菜蔬或者有两个参数。main有两个参数是，第一个参数是命令行的字符串数量。系统用空格标识一个字符串的结束和下一个字符串的开始。
//执行：mainWithArgs demoWords
#include "stdio.h"

int main(int argc, char *argv[])
{
    int count;
    printf("The command line has %d arguments :\n", argc - 1);
    for (count = 1; count < argc; count++)
        printf("%d: %s\n", count, argv[count]);
    printf("\n");
    return 0;
}