using EasyTestAnyThing.DependencyInjection.PlugDemo;

namespace EasyTestAnyThing.DependencyInjection
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