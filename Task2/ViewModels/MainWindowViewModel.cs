using Task2.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task2.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private LivingCreature? _selectedCreature;
        private string _actionLog = string.Empty;

        public LivingCreature[] Creatures { get; } = new LivingCreature[]
        {
            new Panther(),
            new Dog(),
            new Turtle()
        };

        public LivingCreature? SelectedCreature
        {
            get => _selectedCreature;
            set
            {
                _selectedCreature = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanRoar));
                OnPropertyChanged(nameof(CanBark));
                OnPropertyChanged(nameof(CanClimbTree));
            }
        }

        public string ActionLog
        {
            get => _actionLog;
            set
            {
                _actionLog = value;
                OnPropertyChanged();
            }
        }

        public bool CanRoar => SelectedCreature is Panther;
        public bool CanBark => SelectedCreature is Dog;
        public bool CanClimbTree => SelectedCreature is Panther;

        public event PropertyChangedEventHandler? PropertyChanged; // Добавляем nullable

        public MainWindowViewModel()
        {
            foreach (var creature in Creatures)
            {
                if (creature is Panther panther)
                {
                    panther.Roared += (s, e) => AddToLog("Пантера рычит!");
                }
                else if (creature is Dog dog)
                {
                    dog.Barked += (s, e) => AddToLog("Собака лает!");
                }
            }

            SelectedCreature = Creatures[0];
        }

        public void MoveCreature()
        {
            SelectedCreature?.Move();
            UpdateStatus();
        }

        public void StopCreature()
        {
            SelectedCreature?.Stop();
            UpdateStatus();
        }

        public void Roar()
        {
            if (SelectedCreature is Panther panther)
            {
                panther.Roar();
            }
        }

        public void Bark()
        {
            if (SelectedCreature is Dog dog)
            {
                dog.Bark();
            }
        }

        public void ClimbTree()
        {
            if (SelectedCreature is Panther panther)
            {
                panther.ClimbTree();
                AddToLog("Пантера залезла на дерево!");
                UpdateStatus();
            }
        }

        private void UpdateStatus()
        {
            OnPropertyChanged(nameof(SelectedCreature));
            AddToLog($"Состояние: {SelectedCreature?.Status}");
        }

        private void AddToLog(string message)
        {
            ActionLog = $"{DateTime.Now:HH:mm:ss} - {message}\n{ActionLog}";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) // Добавляем nullable
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}