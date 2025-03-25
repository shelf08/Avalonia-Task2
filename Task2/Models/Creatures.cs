using System;

namespace Task2.Models
{
    public abstract class LivingCreature
    {
        public int CurrentSpeed { get; protected set; }
        public abstract int MaxSpeed { get; }

        public abstract void Move();
        public abstract void Stop();

        public virtual string Status => CurrentSpeed == 0 ? "Стоит" : $"Двигается со скоростью {CurrentSpeed}";
    }

    public class Panther : LivingCreature
    {
        public override int MaxSpeed { get; } = 100;
        
        public event EventHandler? Roared; // Добавляем nullable

        public override void Move()
        {
            CurrentSpeed = Math.Min(CurrentSpeed + 20, MaxSpeed);
        }

        public override void Stop()
        {
            CurrentSpeed = Math.Max(CurrentSpeed - 20, 0);
        }

        public void ClimbTree()
        {
            CurrentSpeed = 0;
        }

        public void Roar()
        {
            Roared?.Invoke(this, EventArgs.Empty);
        }

        public override string Status => base.Status + " (Пантера)";
    }

    public class Dog : LivingCreature
    {
        public override int MaxSpeed { get; } = 30;
        
        public event EventHandler? Barked; // Добавляем nullable

        public override void Move()
        {
            CurrentSpeed = Math.Min(CurrentSpeed + 10, MaxSpeed);
        }

        public override void Stop()
        {
            CurrentSpeed = Math.Max(CurrentSpeed - 10, 0);
        }

        public void Bark()
        {
            Barked?.Invoke(this, EventArgs.Empty);
        }

        public override string Status => base.Status + " (Собака)";
    }

    public class Turtle : LivingCreature
    {
        public override int MaxSpeed { get; } = 5;

        public override void Move()
        {
            CurrentSpeed = Math.Min(CurrentSpeed + 1, MaxSpeed);
        }

        public override void Stop()
        {
            CurrentSpeed = Math.Max(CurrentSpeed - 1, 0);
        }

        public override string Status => base.Status + " (Черепаха)";
    }
}