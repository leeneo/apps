using System;
// 冒泡排序
public class BubbleTest {

    private static double[] nums = new double[10]{ 2, 0, 9, 6, 4.2, 5.8 ,0.2,1.5,8.2,-12.4};

    // 从大到小排序
    public static void Tolower () {
        Bubble.Tolower (nums);
        var temp = "";
        foreach (var i in nums) {
            temp += i + ",";
        }
        temp = temp.Remove (temp.Length - 1, 1);
        Console.WriteLine ("{" + temp + "}");
        // Console.WriteLine(Bubble.Comp(22,4));
    }

    // 从小到大排序
    // public static void Tohigher (double[] data) {

    // }
}