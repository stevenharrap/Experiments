using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Saga;
using Automatonymous;
using System.Linq.Expressions;
using Exp002_Sb_SagaCommon;

namespace Exp002_Sb_Saga
{
    public class TrippingStateMachine : MassTransitStateMachine<Trip>
    {
        public TrippingStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => TripStarted, x => x.CorrelateBy(
                (a, b) => a.DeviceId == b.Message.DeviceId && a.DeviceTripId == b.Message.DeviceTripId && b.Message.Ignition)
                .SelectId(context => Guid.NewGuid()));

            Event(() => LogAdded, x => x.CorrelateBy((a, b) => a.DeviceId == b.Message.DeviceId && a.DeviceTripId == b.Message.DeviceTripId));

            Event(() => TripFinished, x => x.CorrelateBy(
                (a, b) => a.DeviceId == b.Message.DeviceId && a.DeviceTripId == b.Message.DeviceTripId && !b.Message.Ignition));

            Initially(
                When(TripStarted)
                    .Then(context => 
                    {
                        //context.Instance.DeviceId = context.Data.DeviceId;
                        //context.Instance.DeviceTripId = context.Data.
                    })
                    .ThenAsync(context => Console.Out.WriteLineAsync($"Trip started {context.Data.DeviceId}, {context.Data.DeviceTripId}. to {context.Instance.CorrelationId}"))
                    .TransitionTo(Active)
                );

            During(Active,
                When(LogAdded)
                    .Then(context => { })
                    .ThenAsync(context => Console.Out.WriteLineAsync($"Log added {context.Data.DeviceId}, {context.Data.DeviceTripId}. to {context.Instance.CorrelationId}")),
                When(TripFinished)
                    .Then(context => { })
                    .ThenAsync(context => Console.Out.WriteLineAsync($"Trip Finished {context.Data.DeviceId}, {context.Data.DeviceTripId}. to {context.Instance.CorrelationId}"))
                    .TransitionTo(Finished)
                    .Finalize()
                );

            SetCompletedWhenFinalized();
        }

        public State Active { get; private set; }

        public State Finished { get; private set; }

        public Event<ITripStarted> TripStarted { get; private set; }

        public Event<ILogAdded> LogAdded { get; private set; }

        public Event<ITripFinished> TripFinished { get; private set; }

        //public Schedule<Trip, ITripExpired> TripExpired { get; private set; }

    }    
}
