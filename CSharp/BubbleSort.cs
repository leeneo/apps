// 冒泡排序
public class BubbleSort
{

    public BubbleSort(){}
    
    // 从大到小排序
    public static void toLowerSort(double[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
        {
            for (int j = data.Length - 1; j > i; j--)
            {
                if (data[j] > data[j - 1])
                {
                    data[j] = data[j] + data[j - 1];
                    data[j - 1] = data[j] - data[j - 1];
                    data[j] = data[j] - data[j - 1];
                }
            }
        }
    }

    // 从小到大排序
    public static void toHighSort(double[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
        {
            for (int j = 0; j < data.Length - 1 - i; j++)
            {
                if (data[j] > data[j + 1])
                {
                    data[j] = data[j] + data[j + 1];
                    data[j + 1] = data[j] - data[j + 1];
                    data[j] = data[j] - data[j + 1];
                }
            }
        }
    }

}
