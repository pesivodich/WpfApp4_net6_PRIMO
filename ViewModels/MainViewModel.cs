using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp4_net6.Helper;
using WpfApp4_net6.Models;
using WpfApp4_net6.Models.WorkModels;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.ViewModels
{
  
    public class MainViewModel : ViewModelBase
    {
        private string nameInput;

        private int SeletedId;

        public string NameInput 
        { 
            get
            {
                return nameInput;
            }
            set
            {
                nameInput = value;
                OnPropertyChanged(nameof(NameInput));

            }

        }
        public string DesInput 
        { 
            get
            {
                return desInput;
            }
            set
            {
                desInput = value;
                OnPropertyChanged(nameof(DesInput));
            }
        }

        public string TestInput 
        {
            get
            {
                return testInput;
            }
            set
            {
                testInput = value;
                OnPropertyChanged(nameof(TestInput));
            }
        }


        private readonly IUnitOfWork _unitOfWork;
  

        private TestTable selectedListItem;
        private string desInput;
        private string testInput;

        public TestTable SelectedListItem
        {
            get { return selectedListItem; }
            set
            {
                if (selectedListItem != value)
                {
                    selectedListItem = value;
                    OnPropertyChanged(nameof(SelectedListItem));

                    if (selectedListItem != null)
                    {
                        SeletedId = SelectedListItem.Id;
                        selectedItem();
                    }

                    
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

        public ICommand SeletedItemUpdate { get; set; }
        public ICommand UpdateItemCommand { get; set; }

        public MainViewModel(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;


            TestTables = new ObservableCollection<TestTable>(_unitOfWork.TestRepository.GetList());



            AddNewUserCmd = new DelegateCommand(AddNewuser, canUser);
            GetSelectedItemCommand = new DelegateCommand(DeleteItem);

            SeletedItemUpdate = new DelegateCommand(selectedItem);

            UpdateItemCommand = new DelegateCommand(UpdateItem, canUpdate);

        }

        private bool canUpdate()
        {
            if(SeletedId != 0)
            {
                return true;
            }
            return false;
        }

        private void UpdateItem()
        {
            var updateItem = new TestWorkModel();
             updateItem.Name = NameInput;
            updateItem.Des = DesInput;
            updateItem.Test = TestInput;

            _unitOfWork.TestRepository.UpdateProduct(SeletedId, updateItem);
            TestTables = new ObservableCollection<TestTable>(_unitOfWork.TestRepository.GetList());

        }

        private void DeleteItem() 
        {
            _unitOfWork.TestRepository.RemoveProduct(SeletedId);
            TestTables = new ObservableCollection<TestTable>(_unitOfWork.TestRepository.GetList());
        }

        private void selectedItem()
        {
          
            var selectUpdate = _unitOfWork.TestRepository.GetFirst(SeletedId);
            NameInput = selectUpdate.Name;
            DesInput = selectUpdate.Des;
            TestInput = selectUpdate.Test;

            TestTables = new ObservableCollection<TestTable>(_unitOfWork.TestRepository.GetList());

        }

        private bool canUser()
        {
            return true;
        }

        private void AddNewuser()
        {
            TestWorkModel input = new TestWorkModel() { Name = NameInput, Des = DesInput, Test = TestInput };
            _unitOfWork.TestRepository.AddNewProduct(input);
            TestTables = new ObservableCollection<TestTable>(_unitOfWork.TestRepository.GetList());

        }


    }
}
