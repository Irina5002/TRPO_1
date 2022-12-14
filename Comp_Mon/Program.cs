using System;

namespace Comp_Mon
{
    //класс монитор
    class Screen
    {
        //конструктор
        public Screen()
        {
            isPowerOn = true;
            currentBrightness = 250;
        }
        //конструктор
        public Screen(int brightness)
        {
            isPowerOn = true;
            currentBrightness = brightness;
        }
        //конструктор
        public Screen(bool isOnOff, int brightness)
        {
            isPowerOn = isOnOff;
            if (!isPowerOn)
                currentBrightness = 0;
            else
                currentBrightness = brightness;
        }
        // состояние монитора
        private bool isPowerOn;
        public bool IsPowerOn
        {
            get { return isPowerOn; }
        }
        //текущая яркость
        private int currentBrightness;
        public int CurrentBrightness
        {
            get { return currentBrightness; }
        }
        // включить монитор
        public void PowerOn()
        {
            isPowerOn = true;
        }
        //выключить монитор
        public void PowerOff()
        {
            isPowerOn = false;
            currentBrightness = 0;
        }
        //поднять яркость
        public void BrightnessUp(int a)
        {
            if (isPowerOn)
                currentBrightness += a;
        }
        //убавить яркость
        public void BrightnessDown(int a)
        {
            currentBrightness -= a;
        }
    }
    //класс компьютер
    class Computer
    {
        //ссылка на объект класса Компьютер
        private static Computer computerInstance;
        //ссылка на объект класса Монитор
        private Screen computerScreen;
        //закрытый конструктор
        public Computer()
        {

        }
        public void setComputerScreen(bool isOn, int brightness)
        {
            computerScreen = new Screen(isOn, brightness);
        }
        public static Computer GetInstanceComputer()
        {
            if (computerInstance == null)
            {
                computerInstance = new Computer();
            }
            return computerInstance;
        }
        //наименование компьютера
        private string nameComputer;
        public string NameComputer
        {
            get { return nameComputer; }
            set { nameComputer = value; }
        }
        //состояние монитора
        public bool IsScreenPowerOn
        {
            get
            {
                return computerScreen.IsPowerOn;
            }
        }
        public void ScreenPowerOn()
        {
            computerScreen.PowerOn();
        }
        public void ScreenPowerOff()
        {
            computerScreen.PowerOff();
        }
        //текущая яркость монитора
        public int ScreenCurrentBrightness
        {
            get
            {
                return computerScreen.CurrentBrightness;
            }
        }
        //прибавить яркость
        public void ScreenBrightnessUp(int a)
        {
            computerScreen.BrightnessUp(a);
        }
        //убавить яркость
        public void ScreenBrightnessDown(int a)
        {
            computerScreen.BrightnessDown(a);
        }
    }

    class Vetka
    {
        public Vetka()
        {
        int vet; 
        }
    }

    class Vetka_2
    {
        public Vetka_2()
        {
            int vet_2;
            //ааааааааааааааааааааааааааааааааа
            //ббббббббббббббббббббббббббббббббб
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //создание объекта синглтон класса Компьютер
            Computer Computer = Computer.GetInstanceComputer();
            Computer.setComputerScreen(false, 300);
            testScreenInComputer("Acer", 100);
            Computer.setComputerScreen(true, 500);
            testScreenInComputer("MSI", 50);
            Console.ReadKey(true);
        }
        private static void testScreenInComputer(string computerName, int brightness)
        {
            Computer Computer = Computer.GetInstanceComputer();
            Computer.NameComputer = computerName;
            PrintInfoOfComputer(Computer);
            //включить монитор
            Computer.ScreenPowerOn();
            //установить яркость
            Computer.ScreenBrightnessUp(brightness);
            PrintInfoOfComputer(Computer);
            //выключить монитор
            Computer.ScreenPowerOff();
            PrintInfoOfComputer(Computer);
        }
        // вывод информации о параметрах компьютера
        private static void PrintInfoOfComputer(Computer Computer)
        {
            Console.WriteLine("{0} монитор включен {1}", Computer.NameComputer, Computer.IsScreenPowerOn);
            Console.WriteLine("Текущая яркость (кд/м^2) {0}", Computer.ScreenCurrentBrightness);
        }
    }
}
