using DenpendencyInjection.PlugDemo.Interface;

namespace DenpendencyInjection.PlugDemo
{   
    public class Sockets
    {
        private readonly IHomeAppliance _firstPlug;
        private readonly IHomeAppliance _secondPlug;
        /// <summary>
        /// 兩孔插座
        /// </summary>
        /// <param name="firstPlug">插座孔一</param>
        /// <param name="secondPlug">插座孔二</param>
        public Sockets(IHomeAppliance firstPlug = null, IHomeAppliance secondPlug = null)
        {
            _firstPlug = firstPlug;
            _secondPlug = secondPlug;
        }

        public void SendPower()
        {
            _firstPlug?.Connect();
            _secondPlug?.Connect();
            if (_firstPlug == null & _secondPlug == null)
            {
                System.Console.WriteLine("Power Already ON, But Nothing Working");
            }
        }
    }
}