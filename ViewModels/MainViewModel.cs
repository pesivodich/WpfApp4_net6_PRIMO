using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp4_net6.Helper;
using WpfApp4_net6.Models;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.ViewModels
{
    public class TestModel 
    {
        public string name { get; set; }    
    }

    public class MainViewModel : ViewModelBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private ObservableCollection<TestModel> testModel { get; set; }

        public ObservableCollection<TestModel> TestModel 
        {
            get
            {
               return testModel;
            }
            set
            {
                testModel = value;
                OnPropertyChanged(nameof(TestModel));
            }
        }

        private TestTable selectedListItem;
        public TestTable SelectedListItem
        {
            get { return selectedListItem; }
            set
            {
                if (selectedListItem != value)
                {
                    selectedListItem = value;
                    OnPropertyChanged(nameof(SelectedListItem));
                }
            }
        }

        private ObservableCollection<TestTable> tstTable { get; set; }

        public ObservableCollection<TestTable> TestTables
        {
            get
            {
                return tstTable;
            }
            set
            {
                tstTable = value;
                OnPropertyChanged(nameof(TestTables));
            }
        }

        public ICommand AddNewUserCmd { get; set; }
        public ICommand GetSelectedItemCommand { get; private set; }

        public MainViewModel(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;


            TestTables = new ObservableCollection<TestTable>(_unitOfWork.TestRepository.GetList());



            AddNewUserCmd = new DelegateCommand(AddNewuser, canUser);
            GetSelectedItemCommand = new DelegateCommand(GetSelectedItem);

        }

        private void GetSelectedItem()
        {
            int selectTest = SelectedListItem.Id;
            _unitOfWork.TestRepository.RemoveProduct(selectTest);
            TestTables = new ObservableCollection<TestTable>(_unitOfWork.TestRepository.GetList());

        }

        private bool canUser()
        {
            return true;
        }

        private void AddNewuser()
        {
            _unitOfWork.TestRepository.AddNewProduct();
            TestTables = new ObservableCollection<TestTable>(_unitOfWork.TestRepository.GetList());

        }


    }
}
