using System;
using MotionSolverLib;

namespace Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TryToFindCoordinateFromTime();
            TryToFindDisplacement();
            TryToFindSomething();
        }

        public static void TryToFindCoordinateFromTime()
        {
            double x = MotionSolver.FindCoordinateFromTime(10, 0, 20, 1);
            Console.WriteLine(x);
        }
        public static void TryToFindDisplacement()
        {
            MotionSolver motionObject = new MotionSolver
            {
                Time = 10.0,
                InitialVelocity = 5.0,
                Acceleration = 2.0
            };
            double displacementAtTime = motionObject.FindDisplacement(motionObject.Time,motionObject.InitialVelocity,motionObject.Acceleration);

            Console.WriteLine(displacementAtTime);
        }
        public static void TryToFindSomething()
        {
            double initialCoordinate = 0.0;
            double initialVelocity = 5.0;
            double velocity = 5.0;
            double acceleration = 2.0;
            double time = 2.0;
            
            double coordinate = MotionSolver.FindCoordinateFromTime(time, initialCoordinate, initialVelocity, acceleration);
            double displacementWithoutTime = MotionSolver.FindDisplacementWithoutTime(velocity, initialVelocity, acceleration);
            double x = MotionSolver.FindVelocityFromTime(time, initialVelocity, acceleration);
            Console.WriteLine(coordinate);
            Console.WriteLine(displacementWithoutTime);
            Console.WriteLine(x);
        }
    }
}