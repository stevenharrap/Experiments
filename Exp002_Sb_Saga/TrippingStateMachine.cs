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
    public class TrippingStateMachine : MassTransitStateMachine<TripState>
    {
        public TrippingStateMachine()
        {
            InstanceState(x => x.State, Active, Completed);
            
            Event(() => TripStarted, x => x.CorrelateById(context => context.Message.CorrelationId));
            Event(() => NewLog, x => x.CorrelateById(context => context.Message.CorrelationId));
            Event(() => TripFinished, x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(                
                When(TripStarted)
                    .Then(HandleTripStarted)
                    .TransitionTo(Active),
                When(NewLog)
                    .Then(HandleNewLog),
                When(TripFinished)
                    .Then(HandleTripFinished)
                    .TransitionTo(Completed)
                );

            DuringAny(
                When(TripStarted)
                    .Then(HandleTripStarted),
                When(TripFinished)
                    .Then(HandleTripFinished)
                    .TransitionTo(Completed)
                );
        }

        public State Active { get; private set; }

        public State Completed { get; private set; }

        public Event<ITripStarted> TripStarted { get; private set; }

        public Event<INewLog> NewLog { get; private set; }

        public Event<ITripFinished> TripFinished { get; private set; }
        
        public void HandleTripStarted(BehaviorContext<TripState, ITripStarted> context)
        {
            context.Instance.CorrelationId = context.Data.CorrelationId;

            //Console.Out.WriteLineAsync($"Trip started {context.Data.Log.DeviceId}, {context.Data.Log.DeviceTripId}. to {context.Instance.CorrelationId}");
            Console.Out.WriteLineAsync($"Trip started. to {context.Instance.CorrelationId}");
        }

        public void HandleTripFinished(BehaviorContext<TripState, ITripFinished> context)
        {
            //Console.Out.WriteLineAsync($"Trip Finished {context.Data.DeviceId}, {context.Data.DeviceTripId}. to {context.Instance.CorrelationId}");
            Console.Out.WriteLineAsync($"Trip Finished. to {context.Instance.CorrelationId}");
        }

        public void HandleNewLog(BehaviorContext<TripState, INewLog> context)
        {
            //Console.Out.WriteLineAsync($"New Log {context.Data.Log.DeviceId}, {context.Data.Log.DeviceTripId}. to {context.Instance.CorrelationId}");
            Console.Out.WriteLineAsync($"New Log. to {context.Instance.CorrelationId}");
        }
    }    
}
