using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using hudao.Core;
using hudao.Core.ViewModels;

namespace hudao.Views.Inventory
{
    public class Test : BasicViewModel
    {
        private DateTime createTime;
        public DateTime CreateTime
        {
            get { return this.createTime; }
            set
            {
                this.createTime = value;
                OnPropertyChanged("CreateTime");
            }
        }

        private string testNo;
        public string TestNo
        {
            get { return this.testNo; }
            set
            {
                this.testNo = value;
                OnPropertyChanged("TestNo");
            }
        }

        private Status status;
        public Status Status
        {
            get { return this.status; }
            set
            {
                this.status = value;
                OnPropertyChanged("Status");
            }
        }

    }

    public class TestXX : BasicViewModel
    {
        private ObservableCollection<Test> items = new ObservableCollection<Test>();
        public ObservableCollection<Test> Items
        {
            get { return this.items; }
            set
            {
                this.items = value;
                OnPropertyChanged("Items");
            }
        }
    }
}
