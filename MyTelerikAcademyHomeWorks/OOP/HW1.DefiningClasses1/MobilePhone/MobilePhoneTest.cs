using System;

namespace MobilePhone
{
    class MobilePhoneTest
    {
        static void Main()
        {
            GSMTest();

            GSMCallHistoryTest();
        }

        private static void GSMTest()
        {
            GSM ph1 = new GSM("Nokia", "MicroSoft", 895, "Peter",
                      new Battery("MyBattery", 500, 125, Battery.BatteryType.LiIon), new Display(4.7,1600000)); 
            GSM ph2 = new GSM("HTC Desire 700", "HTC", 0,null,new Battery(),new Display(5,16000000));
            GSM ph3 = new GSM("Samsung Galaxy S4", "Samsung", 789, "Me", new Battery(), new Display());
            GSM ph4 = new GSM("LG Nexus 5", "Google");

            GSM[] testArray = new GSM[] {ph1, ph2, ph3, ph4,};

            string lines=new string('_', 80);
            Console.WriteLine("GSM Characteristics:\n{0}", lines);

            foreach (var ph in testArray)
            {
                Console.WriteLine(ph);
            }

            Console.WriteLine("This is the static property IPhone4S:\n{0}", GSM.IPhone4S);
        }

        private static void GSMCallHistoryTest()
        {
            GSM testGsm = new GSM("Privileg", "MyFriend");

            testGsm.AddCall(DateTime.Now, "+359895258796", 48);
            testGsm.AddCall(DateTime.Now, "+359872456789", 899);
            testGsm.AddCall(DateTime.Now, "+359973679023", 68);
            testGsm.AddCall(DateTime.Now, "+359111222333", 25);
            testGsm.AddCall(DateTime.Now, "+359444555666", 348);

            testGsm.ShowCallHistory();

            Console.WriteLine("Total call price: " + testGsm.TotalCallPrice());

            testGsm.DeleteCall(1);
            Console.WriteLine("Removed the longest call!");

            Console.WriteLine("Total call price: " + testGsm.TotalCallPrice());

            testGsm.ClearCallHistory();
            Console.WriteLine("Cleared call history!");
            testGsm.ShowCallHistory(); 
        }
    }
}
