﻿using ISW.IoC;
using ISW.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISW
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        private ProductViewModel productViewModel = new ProductViewModel();

        private TestViewModel testViewModel = new TestViewModel();

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "test":
                    CurrentViewModel = testViewModel;
                    break;
                case "product_list":
                default:
                    CurrentViewModel = productViewModel;
                    break;
            }
        }
    }
}
