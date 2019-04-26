using System;
// 冒泡排序
public class Bubble {

    public Bubble () { }

    // private static double[] nums = { 2, 0, 9, 6, 4.2, 5.8 ,0.2};
    // 从大到小排序
    public static void Tolower (double[] data) {
        var data2 = new double[] { };
        var temp = 0.0;
        for (var j = 0; j < data.Length - 1; j++) {
            for (var i = 0; i < data.Length - 1; i++) {
                if (!Comp (data[i], data[i + 1])) {
                    temp = data[i];
                    data[i] = data[i + 1];
                    data[i + 1] = temp;
                }
                // Console.WriteLine (data[i] + ":" + data[i + 1]);
                // Console.WriteLine(!Comp(data[i],data[i+1]));
            }
        }
    }
    internal static bool Comp (double a, double b) {
        if (a < b)
            return false;
        else
            return true;
    }
    // 从小到大排序
    public static void Tohigher (double[] data) {
        for (int i = 0; i < data.Length - 1; i++) {
            for (int j = 0; j < data.Length - 1 - i; j++) {
                if (data[j] > data[j + 1]) {
                    data[j] = data[j] + data[j + 1];
                    data[j + 1] = data[j] - data[j + 1];
                    data[j] = data[j] - data[j + 1];
                }
            }
        }
    }
}