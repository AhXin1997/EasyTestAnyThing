using DenpendencyInjection.PlugDemo;

namespace EasyTestAnyThing.DenpendencyInjection
{
    public class Start
    {
        /*
         * 依賴注入(DI) 練習
         */
        public static void StartMethod() 
        {
            new Sockets(
                new HairDryer(), 
                new SecureHairDryer("Mom")
                ).SendPower();
        }
    }
}