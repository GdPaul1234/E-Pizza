using Projet_Pizzeria.Controller;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Projet_Pizzeria.View
{
    /// <summary>
    /// Logique d'interaction pour CommunicationMessageView.xaml
    /// </summary>
    public partial class CommunicationMessageView : UserControl
    {
        public ObservableCollection<string> MessagesClient { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> MessagesCuisine { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> MessagesLivreur { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> MessagesCommis { get; } = new ObservableCollection<string>();

        private Task _t1, _t2, _t3, _t4;

        public CommunicationMessageView()
        {
            InitializeComponent();
            DataContext = this;

            _t1 = Task.Run(() => ModuleCommunication.ReceiveMessage(DelClientReceiveMesage, "*.client"));
            _t2 = Task.Run(() => ModuleCommunication.ReceiveMessage(DelCommisReceiveMessage, "*.commis"));
            _t3 = Task.Run(() => ModuleCommunication.ReceiveMessage(DelCuisineReceiveMessage, "*.cuisine"));
            _t4 = Task.Run(() => ModuleCommunication.ReceiveMessage(DelLivreurReceiveMessage, "*.livreur"));
        }

        private void DelClientReceiveMesage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                Application.Current.Dispatcher.Invoke(() => MessagesClient.Add(message));
        }

        private void DelCuisineReceiveMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                Application.Current.Dispatcher.Invoke(() => MessagesCuisine.Add(message));
        }

        private void DelLivreurReceiveMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                Application.Current.Dispatcher.Invoke(() => MessagesLivreur.Add(message));
        }

        private void DelCommisReceiveMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                Application.Current.Dispatcher.Invoke(() => MessagesCommis.Add(message));
        }
    }
}