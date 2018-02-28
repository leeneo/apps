using System;

namespace CSharp {

    // 热水器
    public class Heater {
        int temperature;
        public string type = "RealFire 001";    //型号
        public string area = "China Xin";       //产地

        public delegate void BoiledEventHandler (Object sender, BoiledEventArgs param);
        public event BoiledEventHandler Boiled; //event 声明事件,事件必需是委托类型
        // 烧水
        public void BoilWater () {
            for (int i = 0; i < 100; i++) {
                temperature = i;
                if (temperature > 95) {
                    BoiledEventArgs e=new BoiledEventArgs(temperature);
                    OnBoiled(e);
                }
            }
        }
        // 定义BoiledEventArgs类，传递给Observer所感兴趣的信息
        public class　 BoiledEventArgs : EventArgs {
            public readonly int temperature;
            public BoiledEventArgs (int temperature) {
                this.temperature = temperature;
            }
        }

        // 可以供继承自 Heater 的类重写，以便继承类拒绝其他对象对它的监视
        protected virtual void OnBoiled (BoiledEventArgs e) {
            if (Boiled != null)
                Boiled (this, e);
        }
    }

    // 警报器
    public class Alarm {
        public void MakeAlert (Object sender, Heater.BoiledEventArgs e) {
            Heater heater = (Heater) sender;
            Console.WriteLine ("Alarm:{0}-{1}", heater.area, heater.type);
            Console.WriteLine ("Alarm:嘀嘀嘀，水已经{0}度了", e.temperature);
        }
    }

    // 显示器
    public class Display {
        public static void ShowMsg (Object sender, Heater.BoiledEventArgs e) {
            Heater heater = (Heater) sender;
            Console.WriteLine ("Alarm:{0}-{1}", heater.area, heater.type);
            Console.WriteLine ("Display:水快烧开了，当前温度{0}", e.temperature);
        }
    }

    class ObserveDesign {
        public static void TestMain () {
            Heater heater = new Heater ();
            Alarm alarm = new Alarm ();
            heater.Boiled += alarm.MakeAlert;   //注册方法
            heater.Boiled += (new Alarm ()).MakeAlert;  //给匿名对象注册方法
            heater.Boiled += new Heater.BoiledEventHandler (alarm.MakeAlert);   //也可以这么注册
            heater.Boiled += Display.ShowMsg;   //注册静态方法
            heater.BoilWater ();    // 烧水，会自动调用注册过对象的方法
        }
    }

}