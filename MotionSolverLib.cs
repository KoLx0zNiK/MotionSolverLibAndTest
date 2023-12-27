using System;

namespace MotionSolverLib
{
    /// <summary>
    /// Библиотека MotionSolver предоставляет методы для решения задач по равноускоренному прямолинейному движению.
    /// </summary>
    public class MotionSolver
    {
        /// <summary>
        /// Получает или устанавливает время движения.
        /// </summary>
        public double Time { get; set; }

        /// <summary>
        /// Получает или устанавливает начальную координату.
        /// </summary>
        public double InitialCoordinate { get; set; }

        /// <summary>
        /// Получает или устанавливает начальную скорость.
        /// </summary>
        public double InitialVelocity { get; set; }

        /// <summary>
        /// Получает или устанавливает текущую скорость.
        /// </summary>
        public double Velocity { get; set; }

        /// <summary>
        /// Получает или устанавливает ускорение.
        /// </summary>
        public double Acceleration { get; set; }

        /// <summary>
        /// Вычисляет координату в заданный момент времени.
        /// </summary>
        /// <param name="time">Время, прошедшее с начала движения.</param>
        /// <param name="initialCoordinate">Начальная координата.</param>
        /// <param name="initialVelocity">Начальная скорость.</param>
        /// <param name="acceleration">Ускорение.</param>
        /// <returns>Координата в момент времени <paramref name="time"/>.</returns>
        public static double FindCoordinateFromTime(double time, double initialCoordinate, double initialVelocity, double acceleration)
        {
            ValidateInput(time);
            return initialCoordinate + initialVelocity * time + acceleration * time * time * 0.5;
        }

        /// <summary>
        /// Вычисляет перемещение за заданное время.
        /// </summary>
        /// <param name="time">Время, прошедшее с начала движения.</param>
        /// <param name="initialVelocity">Начальная скорость.</param>
        /// <param name="acceleration">Ускорение.</param>
        /// <returns>Перемещение за время <paramref name="time"/>.</returns>
        public double FindDisplacement(double time, double initialVelocity, double acceleration)
        {
            ValidateInput(time);
            return initialVelocity * time + acceleration * time * time * 0.5;
        }

        /// <summary>
        /// Вычисляет перемещение без использования времени.
        /// </summary>
        /// <param name="velocity">Текущая скорость.</param>
        /// <param name="initialVelocity">Начальная скорость.</param>
        /// <param name="acceleration">Ускорение.</param>
        /// <returns>Перемещение при заданных скорости, начальной скорости и ускорении.</returns>
        public static double FindDisplacementWithoutTime(double velocity, double initialVelocity, double acceleration)
        {
            return (velocity * velocity - initialVelocity * initialVelocity) / (2 * acceleration);
        }

        /// <summary>
        /// Вычисляет текущую скорость в заданный момент времени.
        /// </summary>
        /// <param name="time">Время, прошедшее с начала движения.</param>
        /// <param name="initialVelocity">Начальная скорость.</param>
        /// <param name="acceleration">Ускорение.</param>
        /// <returns>Текущая скорость в момент времени <paramref name="time"/>.</returns>
        public static double FindVelocityFromTime(double time, double initialVelocity, double acceleration)
        {
            ValidateInput(time);
            return initialVelocity + acceleration * time;
        }

        /// <summary>
        /// Вычисляет ускорение.
        /// </summary>
        /// <param name="time">Время, прошедшее с начала движения.</param>
        /// <param name="velocity">Текущая скорость.</param>
        /// <param name="initialVelocity">Начальная скорость.</param>
        /// <returns>Ускорение при заданных времени, текущей и начальной скоростях.</returns>
        public static double FindAcceleration(double time, double velocity, double initialVelocity)
        {
            ValidateInput(time);
            return (velocity - initialVelocity) / time;
        }
        
        /// <summary>
        /// Вычисляет время.
        /// </summary>
        /// <param name="initialCoordinate">Координата до начала движения.</param>
        /// <param name="finalCoordinate">Коррдината в конце движения.</param>
        /// <param name="initialVelocity">Начальная скорость.</param>
        /// <param name="finalVelocity">Скорость в конце движения.</param>
        /// <param name="acceleration">Ускорение.</param>
        /// <param name="displacement">Перемещение.</param>
        /// <returns>Время, в течении которого тело двигалось.</returns>
        public static double FindTime(double initialCoordinate, double finalCoordinate, double initialVelocity, double finalVelocity, double acceleration, double displacement)
        {
            if (Math.Abs(acceleration) > double.Epsilon)
            {
                return (finalVelocity - initialVelocity) / acceleration;
            }

            if (Math.Abs(finalCoordinate - initialCoordinate) > double.Epsilon)
            {
                return (finalCoordinate - initialCoordinate) / (finalVelocity - initialVelocity);
            }

            if (Math.Abs(displacement) > double.Epsilon)
            {
                return displacement / (finalVelocity - initialVelocity);
            }

            throw new InvalidOperationException("Unable to calculate time: insufficient information provided.");
        }

        /// <summary>
        /// Проверяет входное значение времени на корректность.
        /// </summary>
        /// <param name="time">Время для проверки.</param>
        private static void ValidateInput(double time)
        {
            if (time < 0)
            {
                throw new ArgumentOutOfRangeException("Time can't be negative.");
            }
        }
    }
}
