using Exp002_Sb_SagaCommon;
using MassTransit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp002_Sb_SagaClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();

            p.Main();
        }

        private async void Main()
        {
            Console.WriteLine("---Tripping Saga Client---");

            var tripTracker = new Dictionary<TripKey, Guid>();
            var bus = Bus.Factory.CreateUsingRabbitMq(x => x.Host(new Uri("rabbitmq://localhost/"), h => { }));
            var busHandle = bus.Start();
            var text = string.Empty;
            var date = new DateTime(2016, 02, 10);

            while (text != "q")
            {
                Console.WriteLine("Enter ?: ");

                var entered = Console.ReadLine();

                Console.WriteLine("First log");
                var log = new Log
                {
                    DeviceId = 5000,
                    DeviceTripId = 9,
                    Timestamp = date.AddMinutes(1),
                    Speed = 0,
                    Ignition = false
                };

                await this.SendLog(log, bus, tripTracker);                
                Console.ReadLine();

                Console.WriteLine("Second log");
                log = new Log
                {
                    DeviceId = 5000,
                    DeviceTripId = 9,
                    Timestamp = date.AddMinutes(2),
                    Speed = 0,
                    Ignition = true
                };
                
                await this.SendLog(log, bus, tripTracker);
                Console.ReadLine();

                Console.ReadLine();

                log = new Log
                {
                    DeviceId = 5000,
                    DeviceTripId = 9,
                    Timestamp = date.AddMinutes(3),
                    Speed = 10,
                    Ignition = true
                };

                await this.SendLog(log, bus, tripTracker);

                log = new Log
                {
                    DeviceId = 5000,
                    DeviceTripId = 9,
                    Timestamp = date.AddMinutes(4),
                    Speed = 80,
                    Ignition = true
                };

                await this.SendLog(log, bus, tripTracker);
            }

            busHandle.Stop();
        }

        private async Task SendLog(ILog log, IBusControl bus, Dictionary<TripKey, Guid> tripTracker)
        {
            Guid id = Guid.Empty;
            tripTracker.TryGetValue(new TripKey(log.DeviceId, log.DeviceTripId), out id);

            if (id == Guid.Empty)
            {
                id = Guid.NewGuid();

                await bus.Publish<ITripStarted>(new TripStarted(id));//, log));
                tripTracker.Add(new TripKey(log.DeviceId, log.DeviceTripId), id);
            }
            else
            {
                await bus.Publish<INewLog>(new NewLog(id, log));
            }
        }
    }

    public struct TripKey : IEqualityComparer<TripKey>
    {
        public readonly int DeviceId;

        public readonly int DeviceTripId;

        public TripKey(int deviceId, int deviceTripId)
        {
            this.DeviceId = deviceId;
            this.DeviceTripId = deviceTripId;
        }

        public bool Equals(TripKey x, TripKey y)
        {
            return x.DeviceId == y.DeviceId && x.DeviceTripId == y.DeviceTripId;
        }

        public int GetHashCode(TripKey obj)
        {
            int hash = 17;

            hash = hash * 23 + obj.DeviceId.GetHashCode();
            hash = hash * 23 + obj.DeviceTripId.GetHashCode();

            return hash;
        }
    }
}
