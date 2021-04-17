using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        private ICommand _ExitClicked;
        private ICommand _CreateCommand;
        private ICommand _ReadCommand;
        private ICommand _UpdateCommand;
        private ICommand _DeleteCommand;
        private string _Description;
        private string _RegistrationNumber;
        private string _Status;
        private ObservableCollection<Entities.Vehicle> vehicles;
        private ObservableCollection<VehicleMake> vehicleMakes;
        private ObservableCollection<VehicleType> vehicleTypes;
        private Vehicle _SelectedVehicle;
        private VehicleType _SelectedType;
        private VehicleMake _SelectedMake;
        private VehicleController Controller;
        #region Constructor
        public MainViewModel()
        {

            ExitClicked = new CommandHandler(new Action<object>(ExitButtonClicked));
            CreateCommand = new CommandHandler(new Action<object>(CreateNewCommand));
            ReadCommand = new CommandHandler(new Action<object>(ReadRecordCommand));
            UpdateCommand = new CommandHandler(new Action<object>(UpdateRecordCommand));
            DeleteCommand = new CommandHandler(new Action<object>(DeleteRecordCommand));
            Controller = new VehicleController();

            LoadData();
        }
        #endregion

        public ICommand ExitClicked
        {
            get { return _ExitClicked; }
            set
            {
                _ExitClicked = value;
                OnPropertyChanged("ExitClicked");
            }
        }
        public ICommand CreateCommand
        {
            get { return _CreateCommand; }
            set
            {
                _CreateCommand = value;
                OnPropertyChanged("CreateCommand");
            }
        }
        public ICommand ReadCommand
        {
            get { return _ReadCommand; }
            set
            {
                _ReadCommand = value;
                OnPropertyChanged("ReadCommand");
            }
        }
        public ICommand UpdateCommand
        {
            get { return _UpdateCommand; }
            set
            {
                _UpdateCommand = value;
                OnPropertyChanged("UpdateCommand");
            }
        }
        public ICommand DeleteCommand
        {
            get { return _DeleteCommand; }
            set
            {
                _DeleteCommand = value;
                OnPropertyChanged("DeleteCommand");
            }
        }
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }
        public string RegistrationNumber
        {
            get { return _RegistrationNumber; }
            set
            {
                _RegistrationNumber = value;
                OnPropertyChanged("RegistrationNumber");
            }
        }
        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged("Status");
            }
        }
        public ObservableCollection<Entities.Vehicle> Vehicles
        {
            get { return vehicles; }
            set
            {
                vehicles = value;
                OnPropertyChanged("Vehicles");
            }
        }
        public ObservableCollection<VehicleMake> VehiclesMakes
        {
            get { return vehicleMakes; }
            set
            {
                vehicleMakes = value;
                OnPropertyChanged("VehiclesMakes");
            }
        }
        public ObservableCollection<VehicleType> VehiclesTypes
        {
            get { return vehicleTypes; }
            set
            {
                vehicleTypes = value;
                OnPropertyChanged("VehiclesTypes");
            }
        }

        public Vehicle SelectedVehicle
        {
            get { return _SelectedVehicle; }
            set
            {
                _SelectedVehicle = value;
                OnPropertyChanged("SelectedVehicle");
            }
        }
        public VehicleType SelectedType
        {
            get { return _SelectedType; }
            set
            {
                _SelectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }
        public VehicleMake SelectedMake
        {
            get { return _SelectedMake; }
            set
            {
                _SelectedMake = value;
                OnPropertyChanged("SelectedMake");
            }
        }

        #region Command Method
        private void UpdateRecordCommand(object p = null)
        {
            if(SelectedVehicle == null)
            {
                MessageBox.Show("Please Select a Vehile");
            }
            else
            {
                Vehicle vehicle = new Vehicle();
                vehicle.RegistrationId = RegistrationNumber;
                vehicle.Id = SelectedVehicle.Id;
                vehicle.Description = Description;

                Controller.CreateOrUpdateVehicle(vehicle);
                Status = "Updating Record";
                MessageBox.Show("Updated");
                LoadData();
            }
        }
        private void ExitButtonClicked(object p = null)
        {
            var window = p as MainWindow;
            window.Close();
        }
        private void CreateNewCommand(object p = null)
        {
            if (SelectedType == null || SelectedMake == null || string.IsNullOrEmpty(RegistrationNumber)) 
            {
                MessageBox.Show("Make, Type or Registration Number is missing ");
            }
            else
            {
                Vehicle vehicle = new Vehicle();

                vehicle.Description = Description;
                vehicle.MakeId = SelectedMake.MakeId;
                vehicle.RegistrationId = RegistrationNumber;
                vehicle.TypeId = SelectedType.TypeId;

                Controller.CreateOrUpdateVehicle(vehicle);
                Status = "Creating New Record";
                MessageBox.Show("New Vehicle Created");
                LoadData();
            }
        }
        private void ReadRecordCommand(object p = null)
        {
            LoadData();
            Status = "Fetching Records Record";
            MessageBox.Show("Records Updated");
        }
        private void DeleteRecordCommand(object p = null)
        {
            if (SelectedVehicle == null)
            {
                MessageBox.Show("Please Select a Vehile");
            }
            else
            {
                Controller.DeleteVehicle(SelectedVehicle.Id);
                Status = "Deleting Record";
                MessageBox.Show("Deleted");
                LoadData();
            }
        }
        #endregion

        private void LoadData()
        {
            var vehiclesCollection = Controller.GetAllVehicles().ToList();
            Vehicles = new ObservableCollection<Entities.Vehicle>(vehiclesCollection);

            VehiclesMakes = new ObservableCollection<VehicleMake>(Controller.GetAllVehicleMake());
            VehiclesTypes = new ObservableCollection<VehicleType>(Controller.GetAllVehicleType());
        }
    }


}
